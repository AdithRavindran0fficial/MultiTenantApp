using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddTaskRepository
{
    public class AddTaskRepo : IAddTaskRepo 
    {
        ITenantProvider tenantProvider;
        public AddTaskRepo(ITenantProvider tenant)
        {
            tenantProvider = tenant;
        }

        public async Task<bool> AddTask(TaskItem task)
        {
            try
            {
                var connectionString = await tenantProvider.GetTenantConnectionString();
                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connectionString); 

                using(var context = new TenantDbContext(builder.Options))
                {
                    await context.Tasks.AddAsync(task);
                    await context.SaveChangesAsync();   
                    return true;    

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
