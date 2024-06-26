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
        public async Task<IActionResult> Get()
        {
            var taskItems = await _taskRepository.GetAllTasks();
            if (taskItems == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(taskItems);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var taskItem = await _taskRepository.GetTaskById(id);
            if(taskItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(taskItem);
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskItem item)
        {
            var isadded = await _taskRepository.AddTask(item);
            if (isadded)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskItem item)
        {
            var isUpdated = await _taskRepository.UpdateTask(id, item);
            if(isUpdated)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var isDeleted = await _taskRepository.DeleteTask(id);
            if (isDeleted)
            {
                Response.StatusCode = StatusCodes.Status204NoContent;
            }
            else
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }

    }
}
