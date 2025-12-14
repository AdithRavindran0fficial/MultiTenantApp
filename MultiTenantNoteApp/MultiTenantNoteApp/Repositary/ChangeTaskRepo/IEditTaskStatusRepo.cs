using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.ChangeTaskRepo
{
    public interface IEditTaskStatusRepo
    {
        Task<bool> EditStatus(UpdateTaskStatusDTO updateTaskStatus);
         
    }
}
