using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Dynamic;
using TaskManagmentAPI.Data;
using TaskManagmentAPI.Interfaces;
using TaskManagmentAPI.Models;

namespace TaskManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private ITaskRepository _taskRepository;
        public TaskItemsController(ITaskRepository repo)
        {
            _taskRepository = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItem>> Get()
        {
             return await _taskRepository.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<TaskItem> Get(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }

        
        [HttpPost]
        public async Task Post([FromBody] TaskItem item)
        {
            await _taskRepository.AddTask(item);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TaskItem item)
        {
            await _taskRepository.UpdateTask(id, item);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _taskRepository.DeleteTask(id);
        }

    }
}
