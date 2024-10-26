namespace BitrixReportGen;

public class TaskData
{
    public string Project { get; set; } = default!;
    public string TaskTitle { get; set; } = default!;
    public int SecondsSpent { get; set; }
    public TimeSpan TimeSpent => TimeSpan.FromSeconds(SecondsSpent);
}