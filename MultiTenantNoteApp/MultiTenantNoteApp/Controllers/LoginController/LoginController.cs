using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantNoteApp.CustomAttribute;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Service.LoginService;
namespace MultiTenantNoteApp.Controllers.LoginController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService login)
        {
            loginService = login;   
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            try
            {
                var result = await loginService.LoginAsync(login);
                if (!result.IsScucces)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);  
                }
            }
            catch(Exception ex)
            {
                var response = new ApiResponse<object>("Internal Server Error", 500, null, ex.Message);
                return StatusCode(500,response);
            }
        }
    }
}
