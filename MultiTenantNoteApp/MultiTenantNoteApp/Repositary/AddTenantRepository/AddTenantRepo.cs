using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using MultiTenantNoteApp.Context.MasterDbContext;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Repositary.AddTenantRepository
{
    public class AddTenantRepo : IAddTenantRepo
    {
        private readonly MasterDbContext masterDbContext;
        private readonly IConfiguration configuration;
        public AddTenantRepo(MasterDbContext masterDb,IConfiguration configuration)
        {
            masterDbContext = masterDb; 
            this.configuration = configuration; 
        }
        public async Task<bool> AddTenant(Tenanats tenanats)
        {
            try
            {
                var existing = await masterDbContext.Tenanats.FirstOrDefaultAsync(x => x.Email == tenanats.Email);
                if(existing ==null)
                {
                    var connection = configuration["TenantConnection:Connection"];
                    var tenantDbName = $"Tenant_{tenanats.TenantName}";
                    var DbnameConnectionString = connection.Replace("{Db_Name}", tenantDbName);
                    tenanats.ConnectionString = DbnameConnectionString;
                    await masterDbContext.Tenanats.AddAsync(tenanats);
                    await masterDbContext.SaveChangesAsync();
                    await MigrateDb(tenanats.ConnectionString);
                    return true;

                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task MigrateDb(string connectionString)
        {
            try
            {
                var builder = new DbContextOptionsBuilder<TenantDbContext>();
                builder.UseSqlServer(connectionString);
                using(var tenantDbContext = new TenantDbContext(builder.Options))
                {
                    await tenantDbContext.Database.MigrateAsync();

                }
            }
            catch(Exception ex)
            {
               
            }
        }
        
    }
}
