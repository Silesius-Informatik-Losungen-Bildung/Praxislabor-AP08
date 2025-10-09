using Microsoft.EntityFrameworkCore;
using StempelApp.Models;

namespace StempelApp.Data
{
    public class StempelAppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public StempelAppDbContext(DbContextOptions<StempelAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "appAdmin" },
                new Role { RoleId = 2, RoleName = "cleaningAdmin" },
                new Role { RoleId = 3, RoleName = "cleaningStaff" },
                new Role { RoleId = 4, RoleName = "buildingOwner" }
            );
        }
    }
}
