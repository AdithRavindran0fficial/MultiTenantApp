using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.GettaskRepository
{
    public class GetTasksRepo : IGetTasksRepo   
    {
        private readonly ITenantProvider tenantProvider;
        public GetTasksRepo(ITenantProvider tenant)
        {
            tenantProvider = tenant;
        }

        public async Task<List<TaskItem>> GetTasksByProject( int projectId)
        {
            try
            {
                var connectionString = await tenantProvider.GetTenantConnectionString();
                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connectionString); 
                using(var context  = new TenantDbContext(builder.Options))
                {
                    var tasks = await context.Tasks.Where(t=>t.ProjectId == projectId).ToListAsync();
                    return tasks;
               }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
