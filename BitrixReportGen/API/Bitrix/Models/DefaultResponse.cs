using System.Text.Json.Serialization;

namespace BitrixReportGen.API.Bitrix.Models;

public class DefaultResponse<T>
{
    [JsonPropertyName("result")] public T? ResultProperty { get; set; }
}