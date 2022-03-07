using BlazorToDo.Models;

namespace BlazorToDo.Repositories;
public interface ICommentRepository
{
    Task<List<TaskComment>> GetAllByTaskId(Guid guid);
    Task<TaskComment> GetByCommentId(Guid guid);
    Task Insert(TaskComment comment);
    Task Update(TaskComment comment);
    Task Delete(Guid guid);
}