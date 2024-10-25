using System.Globalization;
using BitrixReportGen.API.Bitrix.Models;
using RestSharp;

namespace BitrixReportGen.API.Bitrix;

public class SimplifiedBitrixClient(string userId, string apiKey) : BaseClient(new RestClient(baseUrl: string.Create(CultureInfo.InvariantCulture, $"{BaseUrl}/{userId}/{apiKey}")))
{
    private const string BaseUrl = "https://b24-no2e6d.bitrix24.pl/rest";

    private const string GetTaskListEndpoint = "task.planner.getlist.json";
    private const string GetTaskHistoryEndpoint = "tasks.task.history.list.json";
    private const string GetTaskByIdEndpoint = "tasks.task.get.json";

    public async Task<GetTaskList> GetTaskList()
    {
        var req = new RestRequest(new Uri(GetTaskListEndpoint, UriKind.Relative));
        var res = await RequestAsync<GetTaskList>(req).ConfigureAwait(false);

        return res;
    }

    public async Task<GetTaskHistory> GetTaskHistory(string taskId)
    {
        if (string.IsNullOrWhiteSpace(taskId)) throw new ArgumentNullException(nameof(taskId));

        var req = new RestRequest(new Uri(GetTaskHistoryEndpoint, UriKind.Relative));
        req.AddParameter("taskId", taskId);
        var res = await RequestAsync<GetTaskHistory>(req).ConfigureAwait(false);

        return res;
    }

    public async Task<GetTaskById> GetTaskById(string taskId)
    {
        if (string.IsNullOrWhiteSpace(taskId)) throw new ArgumentNullException(nameof(taskId));

        var req = new RestRequest(new Uri(GetTaskByIdEndpoint, UriKind.Relative));
        req.AddParameter("taskId", taskId);
        var res = await RequestAsync<GetTaskById>(req).ConfigureAwait(false);

        return res;
    }
}