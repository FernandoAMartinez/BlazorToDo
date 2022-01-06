using BlazorToDo.Models;
using Blazored.LocalStorage;

namespace BlazorToDo.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        private ILocalStorageService _localStorage;
        private List<TaskModel> tasks;
        public async Task Delete(int id)
        {
            tasks.Remove(tasks.Where(x => x.Id == id).First());
            await Save(tasks);
        }
        public async Task<List<TaskModel>> GetAll()
        {
            if(tasks is null) tasks = await _localStorage.GetItemAsync<List<TaskModel>>("storedTasks");
            return tasks;
        }
        public TaskModel GetById(int id) => tasks.Where(x => x.Id == id).First();

        public async Task Insert(TaskModel task) 
        { 
            tasks.Add(task);
            await Save(tasks);
        }

        public async Task Update(TaskModel task) 
        {
            TaskModel modified = tasks.Where(x => x.Id == task.Id).First();
            tasks.RemoveAt(tasks.IndexOf(modified));
            tasks.Add(task);
            await Save(tasks);
        }

        public async Task Save(List<TaskModel> tasks) => 
            await _localStorage.SetItemAsync<List<TaskModel>>("storedTasks", tasks);
    }
}
