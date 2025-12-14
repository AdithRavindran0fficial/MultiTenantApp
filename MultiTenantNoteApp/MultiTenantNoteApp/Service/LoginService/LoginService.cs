using Microsoft.IdentityModel.Tokens;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Repositary.LoginRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiTenantNoteApp.Service.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo loginRepo;
        private readonly IConfiguration configuration;
        public LoginService(ILoginRepo loginRepo,IConfiguration configuration)
        {
            this.loginRepo = loginRepo;
            this.configuration = configuration; 
        }
        public async Task<ApiResponse<object>> LoginAsync(LoginDTO login)
        {
            try
            {
                if (login == null || string.IsNullOrEmpty(login.Password)|| string.IsNullOrEmpty(login.Email))
                {
                    return new ApiResponse<object>("BadRequest", 400, null, "Input error");
                }
                var result = await loginRepo.Login(login);
                if(result == null)
                {
                    return new ApiResponse<object>("sucess", 200, null,"");
                }
                else
                {
                    var token = await GetToken(result);
                    var data = new LoginResponseDTO
                    {
                        TenantId = result.Id,
                        TenantName = result.TenantName,
                        Token = token

                    };
                    return new ApiResponse<object>("Success",200, data);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<string> GetToken(Tenanats Tenant)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var claim = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,Tenant.Id.ToString()),
                    new Claim(ClaimTypes.Role,Tenant.Role)

                };

                var token = new JwtSecurityToken(
                   signingCredentials: credential,
                   claims: claim,
                   expires: DateTime.UtcNow.AddDays(1));

                return new JwtSecurityTokenHandler().WriteToken(token);
                   
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
