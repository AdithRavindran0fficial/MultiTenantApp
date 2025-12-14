using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.GettaskRepository
{
    public interface IGetTasksRepo
    {
        Task<List<TaskItem>>GetTasksByProject(int projectId);
    }
}
