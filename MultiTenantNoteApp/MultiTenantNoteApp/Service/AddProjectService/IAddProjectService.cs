using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Service.AddProjectService
{
    public interface IAddProjectService
    {
        Task<ApiResponse<object>> AddprojectAsync(AddProjectDTO projectDTO);
    }
}
