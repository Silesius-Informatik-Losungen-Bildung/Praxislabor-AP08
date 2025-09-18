using backendConsoleDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StempelAppCore.Data
{
    public partial class StempelAppContext : DbContext
    {
        public StempelAppContext() { }
        public StempelAppContext(DbContextOptions<StempelAppContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        //public virtual DbSet<Project> Projects { get; set; }
    }
}
