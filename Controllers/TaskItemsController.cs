using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private static List<TaskItem> taskItems = new List<TaskItem>()
        { 
             new TaskItem{Id = 1, Title = "Website Redesign", Description = "Revamp compant website for better user experiemce"},
             new TaskItem{Id = 2, Title = "Marketing campaign", Description = "make people spend more money"},
             new TaskItem{Id = 3, Title = "Product development", Description = "she develop my product"}
        };

        [HttpGet]
        public IEnumerable<TaskItem> Get()
        {
            return taskItems;
        }

        
        [HttpPost]
        public void Post([FromBody] TaskItem item)
        {
            taskItems.Add(item);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskItem item)
        {
            var existingTaskItem = taskItems.FirstOrDefault(t => t.Id == id);
            if (existingTaskItem != null)
            {
                existingTaskItem.Title = item.Title;
                existingTaskItem.Description = item.Description;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingTaskItem = taskItems.FirstOrDefault(t => t.Id == id);
            if (existingTaskItem != null)
            {
                taskItems.Remove(existingTaskItem);
            }
        }

    }
}
