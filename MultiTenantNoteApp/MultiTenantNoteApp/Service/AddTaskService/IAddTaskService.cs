using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Service.AddTaskService
{
    public interface IAddTaskService
    {
        Task<ApiResponse<object>> AddTask(AddTaskDTO addTask);
    }
}
