
using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.MasterDbContext;

namespace MultiTenantNoteApp.Repositary.GetConnectionStringRepository
{
    public class GetTenantConnectionStringRepo : IGetTenantConnectionStringRepo
    {
        MasterDbContext masterDbContext;
        public GetTenantConnectionStringRepo(MasterDbContext masterDb)
        {
            masterDbContext = masterDb; 
        }
        public async Task<string?> GetTenantConnectionStringAsync(int Id)
        {
            try
            {
                var result = await masterDbContext.Tenanats.FirstOrDefaultAsync(t => t.Id == Id);
                return result.ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
