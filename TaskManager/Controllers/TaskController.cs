using Microsoft.AspNetCore.Mvc;
using TaskManager.DataAccess.Repositories;
using TaskManager.Models;


namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly TasksRepository _rep;

        public TaskController(TasksRepository rep)
        {
            _rep = rep;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _rep.GetAll();
            return View("TaskList", tasks);
        }

        [Route("createOrEdit")]
        [HttpPost]
        public async Task<IActionResult> Create(SimpleTask task)
        {
            var _exist = await _rep.IsAny(task.Id);
            if (_exist)
            {
                await _rep.Update(task);
                return Ok();
            }
            var id = await _rep.Create(task);
            return Ok(id);
        }

        [Route("delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        [Route("getById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _rep.GetById(id);
            return Json(task);
        }
    }
}
