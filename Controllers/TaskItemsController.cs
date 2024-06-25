using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private ApiDbContext _context;
        public TaskItemsController(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            return _context.taskItems;
        }

        [HttpGet("{id}")]
        public TaskItem Get(int id)
        {
            return _context.taskItems.FirstOrDefault(t => t.Id == id);
        }

        
        [HttpPost]
        public void Post([FromBody] TaskItem item)
        {
            _context.taskItems.Add(item);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskItem item)
        {
            var existingTaskItem = _context.taskItems.FirstOrDefault(t => t.Id == id);
            if (existingTaskItem != null)
            {
                existingTaskItem.Title = item.Title;
                existingTaskItem.Description = item.Description;
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingTaskItem = _context.taskItems.FirstOrDefault(t => t.Id == id);
            if (existingTaskItem != null)
            {
                _context.taskItems.Remove(existingTaskItem);
                _context.SaveChanges();
            }
        }

    }
}
