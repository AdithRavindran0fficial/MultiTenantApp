using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.MasterDbContext;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.LoginRepository
{

    public class LoginRepo : ILoginRepo
    {
        MasterDbContext masterDbContext;
        public LoginRepo(MasterDbContext masterDb)
        {
            masterDbContext = masterDb;
        }
        public async Task<Tenanats> Login(LoginDTO loginDTO)
        {
            try
            {
                var existing = await masterDbContext.Tenanats.FirstOrDefaultAsync(t=>t.Email == loginDTO.Email && t.Password==loginDTO.Password);
                if (existing == null)
                {
                    return null;
                }
                else
                {
                    return existing;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
