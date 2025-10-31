using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StempelAppApi.Data
{
    public class StempelAppDbContext : IdentityDbContext
    {
        public StempelAppDbContext(DbContextOptions<StempelAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "appAdmin",
                    NormalizedName = "APPADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "cleaningAdmin",
                    NormalizedName = "CLEANINGADMIN"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "cleaningStaff",
                    NormalizedName = "CLEANINGSTAFF"
                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "buildingOwner",
                    NormalizedName = "BUILDINGOWNER"
                }
                    );
                }
    }
}
