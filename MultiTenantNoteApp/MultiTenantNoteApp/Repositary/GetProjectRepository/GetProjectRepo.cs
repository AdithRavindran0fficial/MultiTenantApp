using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.GetProjectRepository
{
    public class GetProjectRepo : IGetProjectRepo
    {
        private readonly ITenantProvider tenantProvider;
        public GetProjectRepo(ITenantProvider tenant)
        {
            tenantProvider = tenant;    
        }
        public async Task<List<Project>> GetProject()
        {
            try
            {
                var connnectionString = await tenantProvider.GetTenantConnectionString();
                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connnectionString);

                using (var context = new TenantDbContext(builder.Options))
                {
                    var projects = await context.Projects.ToListAsync();
                    return projects;
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
