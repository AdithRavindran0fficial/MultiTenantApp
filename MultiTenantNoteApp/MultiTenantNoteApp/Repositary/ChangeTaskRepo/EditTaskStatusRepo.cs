
using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using MultiTenantNoteApp.Models.Enum;

namespace MultiTenantNoteApp.Repositary.ChangeTaskRepo
{
    public class EditTaskStatusRepo : IEditTaskStatusRepo
    {
        ITenantProvider tenantProvider;
        public EditTaskStatusRepo(ITenantProvider tenant)
        {
            tenantProvider = tenant;    
        }
        public async Task<bool> EditStatus(UpdateTaskStatusDTO updateTaskStatus)
        {
            try
            {
                var connectionString = await tenantProvider.GetTenantConnectionString();
                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connectionString);



                using (var context = new TenantDbContext(builder.Options))
                {
                    var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == updateTaskStatus.TaskID);
                    if (updateTaskStatus.TaskStatus == (int)Status.Completed)
                    {
                        task.TaskStatus = Status.Completed.ToString();
                    }
                    else if(updateTaskStatus.TaskStatus == (int)Status.Inprogress)
                    {
                        task.TaskStatus  = Status.Inprogress.ToString();
                    }
                    else if (updateTaskStatus.TaskStatus == (int)Status.Pending)
                    {
                        task.TaskStatus  = Status.Pending.ToString();   
                    }
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
