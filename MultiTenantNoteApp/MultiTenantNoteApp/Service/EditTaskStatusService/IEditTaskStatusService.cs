using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Service.EditTaskStatusService
{
    public interface IEditTaskStatusService
    {
        Task<ApiResponse<object>> EditTaskStatus(UpdateTaskStatusDTO updateTaskStatus);
    }

}
