using BlazorToDo.Models;

namespace BlazorToDo.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAll();
        TaskModel GetById(int id);
        Task Insert(TaskModel task);
        Task Update(TaskModel task);
        Task Delete(int id);
        Task Save(List<TaskModel> tasks);
    }
}
