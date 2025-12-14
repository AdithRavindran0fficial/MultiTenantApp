using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddTenantRepository
{
    public interface IAddTenantRepo
    {
        Task<bool> AddTenant(Tenanats tenanat);
    }
}
