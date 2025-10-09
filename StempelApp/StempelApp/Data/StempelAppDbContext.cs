using Microsoft.EntityFrameworkCore;
using StempelApp.Models;

namespace StempelApp.Data
{
    public class StempelAppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public StempelAppDbContext(DbContextOptions<StempelAppDbContext> options) : base(options) { }
    }
}
