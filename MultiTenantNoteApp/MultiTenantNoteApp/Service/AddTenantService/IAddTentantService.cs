using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Service.AddTenantService
{
    public interface IAddTentantService
    {
        Task<ApiResponse<object>> AddTentantAsync(TenantDTO tenant);
    }
}
