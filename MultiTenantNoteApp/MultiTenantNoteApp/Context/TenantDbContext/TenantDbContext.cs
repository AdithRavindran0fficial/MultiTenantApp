using Microsoft.EntityFrameworkCore;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Models;
using System.Threading.Tasks;

namespace MultiTenantNoteApp.Context.TenantDbContext
{
    public class TenantDbContext : DbContext
    {
        private string? _connectionString;
        public TenantDbContext(DbContextOptions<TenantDbContext> Options)
            :base(Options) 
        {

        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasMany(u => u.Tasks).WithOne(u => u.Project).HasForeignKey(f => f.ProjectId);
        }        
    }
}

