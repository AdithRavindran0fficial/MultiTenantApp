using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Service.AddTenantService;

namespace MultiTenantNoteApp.Controllers.AddTenantController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTenantController : ControllerBase
    {
        private readonly IAddTentantService addTentantService;
        public AddTenantController(IAddTentantService addTentantService)
        {
            this.addTentantService = addTentantService; 
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddTenant(TenantDTO tenant)
        {
            try
            {
                var result = await addTentantService.AddTentantAsync(tenant);
                if (result.IsScucces)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Object>("Internal server error", 500, null, ex.Message);
                return StatusCode(500,response);
            }
        }
    }
}
