using System.Text.Json.Serialization;

namespace BitrixReportGen.API.Bitrix.Models;

/// <summary>
/// FYI: This class has removed the unnecessary properties and classes from the original response.
/// </summary>
public class GetTaskHistory : DefaultResponse<GetTaskHistory.Result>
{
    public class Result
    {
        [JsonPropertyName("list")] public List<History> TaskHistory { get; set; } = [];
    }

    public class History
    {
        // [JsonPropertyName("id")] public string Id { get; set; } = default!;
        [JsonPropertyName("createdDate")] public DateTime CreatedDate { get; set; }
        [JsonPropertyName("field")] public string Field { get; set; } = default!;

        [JsonPropertyName("value")] public Value Value { get; set; } = default!;
        // [JsonPropertyName("user")] public User? User { get; set; }
    }

    // public class User
    // {
    //     [JsonPropertyName("id")] public string Id { get; set; } = default!;
    //     [JsonPropertyName("name")] public string? Name { get; set; }
    //     [JsonPropertyName("lastName")] public string? LastName { get; set; }
    //     [JsonPropertyName("secondName")] public string? SecondName { get; set; }
    //     [JsonPropertyName("login")] public string? Login { get; set; }
    // }

    public class Value
    {
        [JsonPropertyName("from")] public string? From { get; set; }
        [JsonPropertyName("to")] public string? To { get; set; }
    }
}