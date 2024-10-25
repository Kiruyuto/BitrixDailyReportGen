using System.Text.Json;
using RestSharp;
// ReSharper disable UnusedMember.Global

namespace BitrixReportGen.API;

public abstract class BaseClient(RestClient client)
{
    private readonly JsonSerializerOptions _options = new() { Converters = { new DateTimeConverter() } };

    protected async Task<T> RequestAsync<T>(RestRequest request) where T : class
    {
        var res = await client.ExecuteAsync(request);
        if (!res.IsSuccessful)
            throw new Exception($"[{request.Resource} => Status: {res.StatusCode}] Unsuccessful request!\nContent:\n{res.Content}");

        if (string.IsNullOrWhiteSpace(res.Content))
            throw new Exception($"[{request.Resource} => Status: {res.StatusCode}] Received empty response!");

        var model = JsonSerializer.Deserialize<T>(res.Content, _options) ?? throw new Exception($"Failed to deserialize [{request.Resource}] response!");
        return model;
    }
}