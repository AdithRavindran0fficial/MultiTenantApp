using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Service.EditTaskStatusService;

namespace MultiTenantNoteApp.Controllers.EditTaskStatusController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditStatusController : ControllerBase
    {
        private readonly IEditTaskStatusService editTaskStatusService;
        public EditStatusController(IEditTaskStatusService editTaskStatus)
        {
            editTaskStatusService = editTaskStatus;
        }
        [AllowTenant]
        [HttpPost]
        public async Task<IActionResult>EditStatus(UpdateTaskStatusDTO updateTaskStatus)
        {
            try
            {
                var result = await editTaskStatusService.EditTaskStatus(updateTaskStatus);
                if (result.IsScucces)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }catch (Exception ex)
            {
                var response = new ApiResponse<object>("Internal server Error",500,null,ex.Message);
                return StatusCode(500,response);
            }
        }
    }
}
