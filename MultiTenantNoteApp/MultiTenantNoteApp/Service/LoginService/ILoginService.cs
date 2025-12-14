using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Service.LoginService
{
    public interface ILoginService
    {
        Task<ApiResponse<object>> LoginAsync(LoginDTO login);
    }
}
