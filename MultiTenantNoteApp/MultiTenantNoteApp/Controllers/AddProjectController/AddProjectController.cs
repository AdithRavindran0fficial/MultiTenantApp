using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Service.AddProjectService;

namespace MultiTenantNoteApp.Controllers.AddProjectController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProjectController : ControllerBase
    {
        private readonly IAddProjectService addProjectService;
        public AddProjectController(IAddProjectService addProject)
        {
            addProjectService = addProject;
        }
        [AllowTenant]
        [HttpPost]
        public async Task<IActionResult>AddProject(AddProjectDTO addProject)
        {
            try
            {
                var result = await addProjectService.AddprojectAsync(addProject);
                if (result.IsScucces)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
                 
            }
            catch(Exception ex)
            {
                var resposne = new ApiResponse<Object>("Internal Server Error", 500, null, ex.Message);
                return StatusCode(500, resposne);
                
            }
        }
    }
}
