using Microsoft.EntityFrameworkCore;
using School.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel.Dbcontexts
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {
        }
       public DbSet<Admin>Admins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");//this help us entity to database

            modelBuilder.Entity<Admin>().ToTable("Admin");
        }
    }
}
