using System.Text.Json;
using System.Text.Json.Serialization;

namespace BitrixReportGen.API.Bitrix.Models;

public class GetTaskById : DefaultResponse<GetTaskById.Result>
{
    public class Result
    {
        [JsonPropertyName("task")] public Task Task { get; set; } = default!;
    }

    public class Creator
    {
        [JsonPropertyName("id")] public string Id { get; set; } = default!;
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("link")] public string Link { get; set; } = default!;
        [JsonPropertyName("icon")] public string? Icon { get; set; }
        [JsonPropertyName("workPosition")] public string? WorkPosition { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("id")] public string Id { get; set; } = default!;
        [JsonPropertyName("name")] public string Name { get; set; } = default!;
        [JsonPropertyName("opened")] public bool? Opened { get; set; }
        [JsonPropertyName("membersCount")] public int? MembersCount { get; set; }
        [JsonPropertyName("image")] public string? Image { get; set; }
    }

    public class Responsible
    {
        [JsonPropertyName("id")] public string Id { get; set; } = default!;
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("link")] public string Link { get; set; } = default!;
        [JsonPropertyName("icon")] public string? Icon { get; set; }
        [JsonPropertyName("workPosition")] public string? WorkPosition { get; set; }
    }

    public class Task
    {
        [JsonPropertyName("id")] public string Id { get; set; } = default!;
        [JsonPropertyName("title")] public string Title { get; set; } = default!;
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("createdBy")] public string? CreatedByUserId { get; set; }
        [JsonPropertyName("createdDate")] public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("responsibleId")] public string? ResponsibleUserId { get; set; }
        [JsonPropertyName("changedDate")] public DateTime? ChangedDate { get; set; }
        [JsonPropertyName("activityDate")] public DateTime? ActivityDate { get; set; }
        [JsonPropertyName("dateStart")] public DateTime? DateStart { get; set; }
        [JsonPropertyName("commentsCount")] public string? CommentsCount { get; set; }
        [JsonPropertyName("serviceCommentsCount")] public string? ServiceCommentsCount { get; set; }
        [JsonPropertyName("timeEstimate")] public string? TimeEstimate { get; set; }
        [JsonPropertyName("timeSpentInLogs")] public string? TimeSpentInLogs { get; set; } // Returned as string, but represents a number
        [JsonPropertyName("groupId")] public string? GroupId { get; set; }
        public Group? Group;

        [JsonPropertyName("group")]
        public object? Grp
        {
            set
            {
                if (GroupId != null && !string.IsNullOrWhiteSpace(GroupId) && !string.Equals(GroupId, "0", StringComparison.OrdinalIgnoreCase))
                {
                    var str = JsonSerializer.Serialize(value);
                    Group = JsonSerializer.Deserialize<Group>(str);
                }
                else
                {
                    Group = null;
                }
            }
        }

        [JsonPropertyName("creator")] public Creator Creator { get; set; } = default!;
        [JsonPropertyName("responsible")] public Responsible? Responsible { get; set; }
    }
}