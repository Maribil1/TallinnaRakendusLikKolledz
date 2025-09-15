using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseAssigment> CourseAssigments { get; set; }
        public DbSet<OfficeAssigment> OfficeAssigments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<CourseAssigment>().ToTable("CourseAssigment");
            modelBuilder.Entity<OfficeAssigment>().ToTable("OfficeAssigment");
        }
    }
}
