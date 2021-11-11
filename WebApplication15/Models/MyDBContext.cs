using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;


namespace WebApplication15.Models
{
    public class MyDBContext : IdentityDbContext<MyUser>
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IMAD;Database=SchoolWebsite");
        }

       


        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public MyDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
