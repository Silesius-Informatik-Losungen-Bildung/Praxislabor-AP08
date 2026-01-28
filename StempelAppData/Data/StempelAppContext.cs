using StempelAppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace StempelAppCore.Data
{
    public partial class StempelAppContext : DbContext
    {
        public StempelAppContext() { }
        public StempelAppContext(DbContextOptions<StempelAppContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
