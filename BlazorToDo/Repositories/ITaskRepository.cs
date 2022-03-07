using BlazorToDo.Models;

namespace BlazorToDo.Repositories;
public interface ITaskRepository
{
    Task<List<TaskModel>> GetAll();
    //TaskModel GetById(int id);
    Task<TaskModel> GetById(Guid guid);
    Task Insert(TaskModel task);
    Task Update(TaskModel task);
    //Task Delete(int id);
    Task Delete(Guid guid);
    //Task Save(List<TaskModel> tasks);
}