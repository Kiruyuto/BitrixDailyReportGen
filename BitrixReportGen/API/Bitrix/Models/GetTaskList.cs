using System.Text.Json.Serialization;

namespace BitrixReportGen.API.Bitrix.Models;

public class GetTaskList
{
    /// <summary>
    /// For whatever reason, the API coin-flips between list of strings and list of ints, thus the object type.
    /// </summary>
    [JsonPropertyName("result")]
    public List<object> TaskIds { get; set; } = [];
}