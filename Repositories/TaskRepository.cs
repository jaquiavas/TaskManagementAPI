using Microsoft.EntityFrameworkCore;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        ApiDbContext _context;
        public TaskRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task AddTask(TaskItem item)
        {
            await _context.taskItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var existingTaskItem = await _context.taskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTaskItem != null)
            {
                _context.taskItems.Remove(existingTaskItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _context.taskItems.ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _context.taskItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTask(int id, TaskItem item)
        {
            var existingTaskItem = await _context.taskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTaskItem != null)
            {
                existingTaskItem.Title = item.Title;
                existingTaskItem.Description = item.Description;
                await _context.SaveChangesAsync();
            }
        }
    }
}
