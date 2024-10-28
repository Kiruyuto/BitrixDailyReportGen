using System.Globalization;
using System.Text;
using BitrixReportGen.API.Bitrix;

namespace BitrixReportGen;

internal static class Program
{
    private static async Task Main()
    {
        var userId = Environment.GetEnvironmentVariable("BITRIX_USER_ID") ?? throw new Exception("Missing 'BITRIX_USER_ID' environment variable!");
        var apiKey = Environment.GetEnvironmentVariable("BITRIX_API_KEY") ?? throw new Exception("Missing 'BITRIX_API_KEY' environment variable!");
        var bitrixClient = new SimplifiedBitrixClient(userId, apiKey);

        var taskList = await bitrixClient.GetTaskList();

        var bitrixTimezone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");
        var polishTimezone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

        var tasksData = new HashSet<TaskData>();
        foreach (var task in taskList.TaskIds)
        {
            var taskHistory = await bitrixClient.GetTaskHistory(task.ToString()!);
            if (taskHistory.ResultProperty == default) throw new Exception($"[TaskId: {task}] Failed to get task history!");
            var timeSpentTodayEvents = taskHistory.ResultProperty.TaskHistory.Where(x => string.Equals(x.Field, "TIME_SPENT_IN_LOGS", StringComparison.OrdinalIgnoreCase)).ToList();
            if (timeSpentTodayEvents.Count == 0) continue;

            var total = 0;

            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var @event in timeSpentTodayEvents)
            {
                var local = TimeZoneInfo.ConvertTime(@event.CreatedDate, bitrixTimezone, polishTimezone);
                if (local.Date != DateTime.Today.Date) continue;
                total += int.Parse(@event.Value.To!) - int.Parse(@event.Value.From!); // This type of field is always a number
            }

            if (total == 0) continue;

            var taskData = await bitrixClient.GetTaskById(task.ToString()!);
            if (taskData.ResultProperty == default) throw new Exception($"[TaskId: {task}] Failed to get task data!");

            tasksData.Add(new TaskData
            {
                Project = taskData.ResultProperty.Task.Group != null ? $"{taskData.ResultProperty.Task.Group.Name}" : "No project",
                TaskTitle = $"{taskData.ResultProperty.Task.Title}",
                SecondsSpent = total
            });
        }

        Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Found {tasksData.Count} tasks for today ({DateTime.Today:dd.MM.yyyy})"));
        if (tasksData.Count == 0) return;

        var tasksByProject = tasksData.GroupBy(x => x.Project, StringComparer.OrdinalIgnoreCase);

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Create(CultureInfo.InvariantCulture, $"# Daily report for {DateTime.Today:dd.MM.yyyy}, created at {DateTime.Now:HH:mm:ss} #\n"));
        foreach (var projectTasks in tasksByProject)
        {
            stringBuilder.AppendLine($"### [{projectTasks.Key}] => {projectTasks.Sum(x => x.TimeSpent.Hours)}h {projectTasks.Sum(x => x.TimeSpent.Minutes)}m {projectTasks.Sum(x => x.TimeSpent.Seconds)}s ###");
            foreach (var task in projectTasks)
                stringBuilder.AppendLine($"- {task.TaskTitle} => {task.TimeSpent.Hours}h {task.TimeSpent.Minutes}m {task.TimeSpent.Seconds}s");
        }

        stringBuilder.AppendLine(string.Create(CultureInfo.InvariantCulture, $"\nTotal time spent today across all projects: [{tasksData.Sum(x => x.TimeSpent.Hours)}h {tasksData.Sum(x => x.TimeSpent.Minutes)}m {tasksData.Sum(x => x.TimeSpent.Seconds)}s]"));

        var strToClipboard = stringBuilder.ToString();
        Console.WriteLine("Tasks to report:\n" + strToClipboard);
        var isCopied = await ClipboardManager.SetClipboard(strToClipboard);

        Console.WriteLine(isCopied ? "Successfully copied to clipboard! Use Ctrl+V to paste it." : "Failed to copy to clipboard! Most likely you are not on Windows.");
    }
}