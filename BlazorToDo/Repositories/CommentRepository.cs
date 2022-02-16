using BlazorToDo.Models;
using System.Net.Http.Headers;

namespace BlazorToDo.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly HttpClient _client;
    public CommentRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task Delete(Guid guid)
    {
        var response = await _client.DeleteAsync($"/api/tasks/comments/{guid}");

        if (response.IsSuccessStatusCode)
        {

        }

    }

    public async Task<List<TaskComment>> GetAllByTaskId(Guid guid)
    {
        List<TaskComment> comments = new();

        var response = await _client.GetAsync($"/api/tasks/{guid}/comments");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (content is not null)
            {
                comments = System.Text.Json.JsonSerializer.Deserialize<List<TaskComment>>(content);
            }
        }

        return comments;
    }

    public async Task<TaskComment> GetByCommentId(Guid guid)
    {
        TaskComment comment = new();

        var response = await _client.GetAsync($"/api/tasks/comments/{guid}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (content is not null)
            {
                comment = System.Text.Json.JsonSerializer.Deserialize<TaskComment>(content);
            }
        }

        return comment;
    }

    public async Task Insert(TaskComment comment)
    {
        HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comment), System.Text.Encoding.UTF8);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PostAsync($"/api/tasks/comments/", content);

        if (response.IsSuccessStatusCode)
        {

        }
    }

    public async Task Update(TaskComment comment)
    {
        HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(comment), System.Text.Encoding.UTF8);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PutAsync($"/api/tasks/comments/", content);

        if (response.IsSuccessStatusCode)
        {

        }

    }
}