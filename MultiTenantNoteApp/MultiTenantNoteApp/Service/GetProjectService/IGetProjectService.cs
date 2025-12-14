using MultiTenantNoteApp.Helper;

namespace MultiTenantNoteApp.Service.GetProjectService
{
    public interface IGetProjectService
    {
        Task<ApiResponse<object>> GetProjectAsync();
    }
}
