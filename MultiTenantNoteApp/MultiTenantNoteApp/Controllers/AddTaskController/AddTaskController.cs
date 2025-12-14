using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Service.AddTaskService;
namespace MultiTenantNoteApp.Controllers.AddTaskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTaskController : ControllerBase
    {
        private readonly IAddTaskService addTaskService;
        public AddTaskController(IAddTaskService addTask)
        {
            addTaskService = addTask;
        }
        [AllowTenant]
        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskDTO task)
        {
            try
            {
                var result= await addTaskService.AddTask(task);
                if (result.IsScucces)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>("Internal Server Error", 500, null, ex.Message);
                return StatusCode(500, response);
            }
        }
    }
}
