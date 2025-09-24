using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using TallinnaRakendusLikKolledz.Models;

namespace TallinnaRakendusLikKolledz.Data
{
    public class DbInitializer 
    {
        public static void Initializer(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student
                {
                    FirstName = "sdf",
                    LastName = "AAA",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Abra",
                    LastName = "Kadabra",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Nipi",
                    LastName = "Tiri",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Taavi",
                    LastName = "Tamm",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Heli",
                    LastName = "Redel",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Pori",
                    LastName = "Kärber",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Donald",
                    LastName = "Duck",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                },
                new Student
                {
                    FirstName = "Super",
                    LastName = "Mario",
                    EnrollmentDate = DateTime.Now,
                    Gender = "M",
                    Age = 21,
                    Birthday = 2007
                }

            };
            context.Students.AddRange(students);
            context.SaveChanges();
            if (context.Courses.Any()) { return; }
            var courses = new Course[]
            {
                new Course {CourseId=1001, Title="Programmeerimise Alused", Credits=3 },
                new Course {CourseId=2002, Title="Programmeerimise 1", Credits=6 },
                new Course {CourseId=3003, Title="Programmeerimise 2", Credits=9},
                new Course {CourseId=2003, Title="Tarkvara Arendusprotsess", Credits=3 },
                new Course {CourseId=1002, Title="Multimeedia", Credits=3 },
                new Course {CourseId=3001, Title="Harjusrakenduste Alused", Credits=3 },
                new Course {CourseId=9001, Title="CRYPTOBRO 101", Credits=0 },

            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            if (!context.Enrollments.Any()) { return; }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=1, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=2, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment{StudentID=2, CourseID=3001, CurrentGrade=Grade.MA},
                new Enrollment{StudentID=3, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment{StudentID=3, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment{StudentID=4, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=4, CourseID=2002, CurrentGrade=Grade.B},
                new Enrollment{StudentID=5, CourseID=1002, CurrentGrade=Grade.C},
                new Enrollment{StudentID=5, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=6, CourseID=3001, CurrentGrade=Grade.MA},
                new Enrollment{StudentID=6, CourseID=2003, CurrentGrade=Grade.A},
                new Enrollment{StudentID=7, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=7, CourseID=2002, CurrentGrade=Grade.X},

            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            if(context.Instructors.Any()) { return; }
            var instructors = new Instructor[]
            {
                new Instructor{FirstName="DONKEH", LastName="Dragon", HireDate=DateTime.Now, Gender="Male" },
                new Instructor{FirstName="SHREK", LastName="Swamp", HireDate=DateTime.Now, Gender="Male" },
                new Instructor{FirstName="Fiona", LastName="Castle", HireDate=DateTime.Now, Gender="Female" },
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();


        }
    }
}
