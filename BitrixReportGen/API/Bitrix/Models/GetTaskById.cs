using System.Text.Json.Serialization;

namespace BitrixReportGen.API.Bitrix.Models;

public class GetTaskById : DefaultResponse<GetTaskById.Result>
{
    public class Result
    {
        [JsonPropertyName("task")] public Task Task { get; set; }
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
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("opened")] public bool? Opened { get; set; }
        [JsonPropertyName("membersCount")] public int? MembersCount { get; set; }
        [JsonPropertyName("image")] public string Image { get; set; }
    }

    public class Responsible
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("link")] public string Link { get; set; }
        [JsonPropertyName("icon")] public string Icon { get; set; }
        [JsonPropertyName("workPosition")] public string WorkPosition { get; set; }
    }



    public class Task
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("priority")] public string Priority { get; set; }
        [JsonPropertyName("multitask")] public string Multitask { get; set; }
        [JsonPropertyName("notViewed")] public string NotViewed { get; set; }
        [JsonPropertyName("replicate")] public string Replicate { get; set; }
        [JsonPropertyName("stageId")] public string StageId { get; set; }
        [JsonPropertyName("createdBy")] public string CreatedBy { get; set; }
        [JsonPropertyName("createdDate")] public DateTime? CreatedDate { get; set; }
        [JsonPropertyName("responsibleId")] public string ResponsibleId { get; set; }
        [JsonPropertyName("changedBy")] public string ChangedBy { get; set; }
        [JsonPropertyName("changedDate")] public DateTime? ChangedDate { get; set; }
        [JsonPropertyName("statusChangedBy")] public string StatusChangedBy { get; set; }
        [JsonPropertyName("closedBy")] public string ClosedBy { get; set; }
        [JsonPropertyName("activityDate")] public DateTime? ActivityDate { get; set; }
        [JsonPropertyName("dateStart")] public DateTime? DateStart { get; set; }
        [JsonPropertyName("guid")] public string Guid { get; set; }
        [JsonPropertyName("commentsCount")] public string CommentsCount { get; set; }
        [JsonPropertyName("serviceCommentsCount")] public string ServiceCommentsCount { get; set; }
        [JsonPropertyName("allowChangeDeadline")] public string AllowChangeDeadline { get; set; }
        [JsonPropertyName("allowTimeTracking")] public string AllowTimeTracking { get; set; }
        [JsonPropertyName("taskControl")] public string TaskControl { get; set; }
        [JsonPropertyName("addInReport")] public string AddInReport { get; set; }
        [JsonPropertyName("timeEstimate")] public string TimeEstimate { get; set; }
        [JsonPropertyName("timeSpentInLogs")] public string TimeSpentInLogs { get; set; }
        [JsonPropertyName("matchWorkTime")] public string MatchWorkTime { get; set; }
        [JsonPropertyName("forumTopicId")] public string ForumTopicId { get; set; }
        [JsonPropertyName("forumId")] public string ForumId { get; set; }
        [JsonPropertyName("siteId")] public string SiteId { get; set; }
        [JsonPropertyName("subordinate")] public string Subordinate { get; set; }
        [JsonPropertyName("outlookVersion")] public string OutlookVersion { get; set; }
        [JsonPropertyName("viewedDate")] public DateTime? ViewedDate { get; set; }
        [JsonPropertyName("durationFact")] public string DurationFact { get; set; }
        [JsonPropertyName("isMuted")] public string IsMuted { get; set; }
        [JsonPropertyName("isPinned")] public string IsPinned { get; set; }
        [JsonPropertyName("isPinnedInGroup")] public string IsPinnedInGroup { get; set; }
        [JsonPropertyName("descriptionInBbcode")] public string DescriptionInBbcode { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("statusChangedDate")] public DateTime? StatusChangedDate { get; set; }
        [JsonPropertyName("durationPlan")] public string DurationPlan { get; set; }
        [JsonPropertyName("durationType")] public string DurationType { get; set; }
        [JsonPropertyName("groupId")] public string? GroupId { get; set; }
        [JsonPropertyName("group")] public Group? Group { get; set; }
        [JsonPropertyName("creator")] public Creator Creator { get; set; } = default!;
        [JsonPropertyName("responsible")] public Responsible? Responsible { get; set; }
    }
}