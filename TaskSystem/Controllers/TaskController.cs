using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Model;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskSystem.Model.Task>>> findAllTasks()
        {
            List<TaskSystem.Model.Task> tasksList = await _taskRepository.findAllTasks();
            return Ok(tasksList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskSystem.Model.Task>>> findById(int id)
        {
            TaskSystem.Model.Task task = await _taskRepository.findById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskSystem.Model.Task>> Register([FromBody] TaskSystem.Model.Task task)
        {
            TaskSystem.Model.Task _task = await _taskRepository.add(task);
            return Ok(_task);
        }

        [HttpPut]
        public async Task<ActionResult<TaskSystem.Model.Task>> Update([FromBody] TaskSystem.Model.Task task, int id)
        {
            task.Id = id;
            TaskSystem.Model.Task _task = await _taskRepository.update(task, id);
            return Ok(_task);
        }

        [HttpDelete]
        public async Task<ActionResult<TaskSystem.Model.Task>> Delete(int id)
        {
            bool deleted = await _taskRepository.remove(id);
            return Ok(deleted);
        }
    }
}
