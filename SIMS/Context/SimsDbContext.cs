using Microsoft.EntityFrameworkCore;
using SIMS.Models;

namespace SIMS.Context
{
    public class SimsDbContext:DbContext
    {
        public SimsDbContext(DbContextOptions<SimsDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(s => s.DateOfBirth).HasColumnType("date");

            //modelBuilder.Entity<Student>().HasKey(s => s.Id);
            //modelBuilder.Entity<Course>().HasKey(s => s.Id);
            //modelBuilder.Entity<Grade>().HasKey(s => s.Id);
            //modelBuilder.Entity<StudentCourse>().HasKey(s => new { s.Id, s.CourseId, s.GradeId });

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
