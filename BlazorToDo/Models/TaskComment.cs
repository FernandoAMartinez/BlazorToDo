using System.Text.Json.Serialization;

namespace BlazorToDo.Models;
public class TaskComment
{
    public TaskComment()
    {

    }
    [JsonPropertyName("_id")] public Guid Id { get; set; }
    [JsonPropertyName("taskId")] public Guid TaskId { get; set; }
    [JsonPropertyName("commentId")] public int CommentId { get; set; }
    [JsonPropertyName("commentText")] public string CommentText { get; set; }
    [JsonPropertyName("commentDate")] public DateTime CommentDate { get; set; }
}