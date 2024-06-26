using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();

        Task<TaskItem> GetTaskById(int id);

        Task AddTask(TaskItem item);

        Task UpdateTask(int id, TaskItem item);

        Task DeleteTask(int id);
    }
}
