using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddProjectRepository
{
    public interface IAddProjectRepo
    {
        Task<bool> AddProject(Project project);
    }
}
