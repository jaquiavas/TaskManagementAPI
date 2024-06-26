using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();

        Task<TaskItem> GetTaskById(int id);

        Task<bool> AddTask(TaskItem item);

        Task<bool> UpdateTask(int id, TaskItem item);

        Task<bool> DeleteTask(int id);
    }
}
