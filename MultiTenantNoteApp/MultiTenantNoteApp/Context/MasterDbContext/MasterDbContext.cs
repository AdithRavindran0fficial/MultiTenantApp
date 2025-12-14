using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Models;

namespace MultiTenantNoteApp.Context.MasterDbContext
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> option)
            :base(option)
        {
                       
        }
        public DbSet<Tenanats> Tenanats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenanats>().Property(p=>p.ConnectionString).IsRequired();
        }
    }
}
