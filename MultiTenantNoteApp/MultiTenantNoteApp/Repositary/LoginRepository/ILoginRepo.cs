using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.LoginRepository
{
    public interface ILoginRepo
    {
        Task<Tenanats>Login(LoginDTO loginDTO);
    }
}
