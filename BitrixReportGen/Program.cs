using System.Collections;
using System.Diagnostics;
using System.Globalization;
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

        var tasksToReport = new Hashtable();
        foreach (var task in taskList.TaskIds)
        {
            var taskHistory = await bitrixClient.GetTaskHistory(task.ToString()!);
            if (taskHistory.ResultProperty == default) throw new Exception($"[TaskId: {task}] Failed to get task history!");
            var timeSpentTodayEvents = taskHistory.ResultProperty.TaskHistory.Where(x => string.Equals(x.Field, "TIME_SPENT_IN_LOGS", StringComparison.OrdinalIgnoreCase) && x.CreatedDate.Date == DateTime.Today.Date).ToList();
            if (timeSpentTodayEvents.Count == 0) continue;

            var total = 0;

            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var @event in timeSpentTodayEvents)
                total += int.Parse(@event.Value.To!) - int.Parse(@event.Value.From!); // This type of field is always a number

            if (total == 0) continue;

            var taskData = await bitrixClient.GetTaskById(task.ToString()!);
            if (taskData.ResultProperty == default) throw new Exception($"[TaskId: {task}] Failed to get task data!");

            var taskTimespan = TimeSpan.FromSeconds(total);
            var title = $"[{taskData.ResultProperty.Task.Title}]";
            var group = (taskData.ResultProperty.Task.Group != null ? $"[{taskData.ResultProperty.Task.Group.Name}]" : "");
            tasksToReport.Add(group, string.Create(CultureInfo.InvariantCulture, $"{title}{group} Total time spent today: {taskTimespan.Hours}h {taskTimespan.Minutes}m {taskTimespan.Seconds}s"));
        }

        Console.WriteLine("Tasks to report:");
        foreach (var s in tasksToReport) Console.WriteLine(s);

        var strToClipboard = string.Join('\n', tasksToReport);
        var isCopied = SetClipboard(strToClipboard);

        Console.WriteLine(isCopied ? "Successfully copied to clipboard! Use Ctrl+V to paste it." : "Failed to copy to clipboard! Most likely you are not on Windows.");
    }

    private static bool SetClipboard(string value)
    {
        if (!OperatingSystem.IsWindows())
            return false;

        ArgumentNullException.ThrowIfNull(value);

        var clipboardExecutable = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                FileName = "clip",
                UseShellExecute = false
            }
        };

        clipboardExecutable.Start();

        try
        {
            clipboardExecutable.StandardInput.Write(value); // CLIP uses STDIN as input.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to copy to clipboard! Exception: {ex}");
            return false;
        }
        finally
        {
            clipboardExecutable.StandardInput.Close();
        }

        return true;
    }
}