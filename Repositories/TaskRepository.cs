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
        public async Task<bool> AddTask(TaskItem item)
        {
            try { 
                await _context.taskItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var existingTaskItem = await _context.taskItems.FirstOrDefaultAsync(t => t.Id == id);
                if (existingTaskItem != null)
                {
                    _context.taskItems.Remove(existingTaskItem);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch 
            {               
                return false;
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

        public async Task<bool> UpdateTask(int id, TaskItem item)
        {
            try
            {
                var existingTaskItem = await _context.taskItems.FirstOrDefaultAsync(t => t.Id == id);
                if (existingTaskItem != null)
                {
                    existingTaskItem.Title = item.Title;
                    existingTaskItem.Description = item.Description;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
