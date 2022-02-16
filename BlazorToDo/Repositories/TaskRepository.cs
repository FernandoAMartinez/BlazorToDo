using BlazorToDo.Models;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BlazorToDo.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly HttpClient _client;
    public TaskRepository(ILocalStorageService localStorage, HttpClient client)
    {
        _localStorage = localStorage;
        _client = client;
    }

    private readonly ILocalStorageService _localStorage;
    private List<TaskModel> tasks;
    
    //public async Task Delete(int id)
    public async Task Delete(Guid guid)
    {
        //tasks.Remove(tasks.First(x => x.Id == id));
        //tasks.Remove(tasks.First(x => x.Id == guid));
        //await Save(tasks);
        var response = await _client.DeleteAsync($"/api/tasks/{guid}");

        if (response.IsSuccessStatusCode)
        {

        }

    }
    public async Task<List<TaskModel>> GetAll()
    {
        //if(tasks is null) tasks = await _localStorage.GetItemAsync<List<TaskModel>>("storedTasks");

        var user_id = await _localStorage.GetItemAsStringAsync("user_id");
        
        tasks = new();

        var response = await _client.GetAsync($"/api/{user_id}/tasks");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if(content is not null)
            {
                tasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskModel>>(content);
            }
        }
            
        return tasks;
    }
    //public TaskModel GetById(int id) => tasks.First(x => x.Id == id);
    //public TaskModel GetById(Guid guid) => tasks.First(x => x.Id == guid);
    public async Task<TaskModel> GetById(Guid guid)
    {
        TaskModel task = new();
        var response = await _client.GetAsync($"/api/tasks/{guid}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (content is not null)
            {
                task = System.Text.Json.JsonSerializer.Deserialize<TaskModel>(content);
            }
        }

        return task;
    }

    public async Task Insert(TaskModel task) 
    {
        //TODO: Add POST request to API
        //tasks.Add(task);
        //await Save(tasks);
        HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(task), System.Text.Encoding.UTF8);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PostAsync($"/api/tasks", content);

        if (response.IsSuccessStatusCode)
        {
            
        }

    }

    public async Task Update(TaskModel task) 
    {
        //TODO: Add PUT request to API
        //TaskModel modified = tasks.Where(x => x.Id == task.Id).First();
        //tasks.RemoveAt(tasks.IndexOf(modified));
        //tasks.Add(task);
        //await Save(tasks);
        HttpContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(task), System.Text.Encoding.UTF8);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PutAsync($"/api/tasks", content);

        if (response.IsSuccessStatusCode)
        {

        }

    }

    //public async Task Save(List<TaskModel> tasks) => 
    //    await _localStorage.SetItemAsync<List<TaskModel>>("storedTasks", tasks);
}