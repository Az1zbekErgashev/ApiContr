using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enitiy;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TaskController : ControllerBase
    {   
        private ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository) => _taskRepository = taskRepository;
        [HttpGet]
        public async Task<ActionResult<Enitiy.Task>> GetTask() => Ok(await _taskRepository.GetAllTasks());
        [HttpPost]
        public async Task<ActionResult> AddTask(Enitiy.Task task) => Ok(await _taskRepository.CreateTask(task));
        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
            return Ok("Task is delete");
        }
        [HttpPut]
        public async Task<ActionResult<Enitiy.Task>> UpdateReview(Enitiy.Task task) => Ok(await _taskRepository.UpdateTask(task));
    }
}
