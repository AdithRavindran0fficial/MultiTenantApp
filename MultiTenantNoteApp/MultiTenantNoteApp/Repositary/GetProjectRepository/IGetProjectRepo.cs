using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.GetProjectRepository
{
    public interface IGetProjectRepo
    {
        Task<List<Project>> GetProject();
    }
}
