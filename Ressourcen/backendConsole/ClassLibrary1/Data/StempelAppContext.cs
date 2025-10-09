using Microsoft.EntityFrameworkCore;
using StempelAppCore.Models.Domain;

namespace StempelAppCore.Data
{
    public partial class StempelAppContext : DbContext
    {
        public StempelAppContext() { }
        public StempelAppContext(DbContextOptions<StempelAppContext> options) : base(options) { }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<UserAssignment> Assignments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
