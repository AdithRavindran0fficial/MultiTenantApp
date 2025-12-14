using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.ChangeTaskRepo
{
    public interface IEditTaskStatusPending
    {
        Task<bool> EditStatusToPending(UpdateTaskStatusDTO updateTaskStatusDTO);
        
    }

}