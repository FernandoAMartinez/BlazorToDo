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
        public List<TaskModel> Tasks { get; set; }
        public async Task Delete(int id)
        {
            Tasks.Remove(Tasks.Where(x => x.Id == id).First());
            await Save(Tasks);
        }
        public async Task<List<TaskModel>> GetAll()
        {
            Tasks = await _localStorage.GetItemAsync<List<TaskModel>>("storedTasks");
            return Tasks;
        }
        public TaskModel GetById(int id) => Tasks.Where(x => x.Id == id).First();

        public async Task Insert(TaskModel task) 
        { 
            Tasks.Add(task);
            await Save(Tasks);
        }

        public async Task Update(TaskModel task) 
        {
            TaskModel modified = Tasks.Where(x => x.Id == task.Id).First();
            Tasks.RemoveAt(Tasks.IndexOf(modified));
            Tasks.Add(task);
            await Save(Tasks);
        }

        public async Task Save(List<TaskModel> tasks) => 
            await _localStorage.SetItemAsync<List<TaskModel>>("storedTasks", tasks);
    }
}
