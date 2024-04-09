
using WebAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //define the tables -> by convention they are plural
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Course entity
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);  // Specify primary key

            // Configure Teacher entity
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.TeacherId);  // Specify primary key

            // Configure relationship between Course and Teacher
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);  // Specify foreign key
        }
    }
}