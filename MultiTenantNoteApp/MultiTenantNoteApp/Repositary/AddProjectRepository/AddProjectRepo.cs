using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddProjectRepository
{
    public class AddProjectRepo : IAddProjectRepo
    {
        private readonly ITenantProvider  tenantProvider;

        public AddProjectRepo(ITenantProvider tenant)
        {
            tenantProvider = tenant;    
        }
        public async Task<bool> AddProject(Project project)
        {
            try
            {
                var connectionstring = await tenantProvider.GetTenantConnectionString();

                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connectionstring);

                using(var context = new TenantDbContext(builder.Options))
                {
                    await context.Projects.AddAsync(project);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
