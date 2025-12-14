using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Service.GetProjectService;

namespace MultiTenantNoteApp.Controllers.GetProjectController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProjectsController : ControllerBase
    {
        private readonly IGetProjectService _projectService;
        public GetProjectsController(IGetProjectService getProject )
        {
            _projectService = getProject;   
        }
        [AllowTenant]
        [HttpGet]
        public async Task<IActionResult> GetProject()
        {
            try
            {
                var result = await _projectService.GetProjectAsync();
                return Ok(result);
            }
            catch(Exception ex)
            {
                var response = new ApiResponse<object>("Internal Server Error",500,null,ex.Message);
                return StatusCode(500,response);
            }


        }
    }
}
