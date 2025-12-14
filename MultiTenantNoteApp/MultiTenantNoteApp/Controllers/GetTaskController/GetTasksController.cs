using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Service.GetTaskService;

namespace MultiTenantNoteApp.Controllers.GetTaskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTasksController : ControllerBase
    {
        private readonly IGetTaskService getTaskService;
        public GetTasksController(IGetTaskService getTask)
        {
            getTaskService = getTask;   
        }
        [AllowTenant]
        [HttpGet]
        public async Task<IActionResult>GetTasks([FromQuery]int projectId)
        {
            try
            {
                var result = await getTaskService.GetTasks(projectId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var response = new ApiResponse<object>("Internal Server Error", 500, null, ex.Message);
                return StatusCode(500, response);
            }
        }

    }
}
