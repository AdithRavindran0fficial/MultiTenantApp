using MultiTenantNoteApp.Helper;

namespace MultiTenantNoteApp.Service.GetTaskService
{
    public interface IGetTaskService
    {
        Task<ApiResponse<object>> GetTasks(int id);
    }
}
