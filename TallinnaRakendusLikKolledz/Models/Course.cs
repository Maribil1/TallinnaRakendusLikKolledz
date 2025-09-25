using System.ComponentModel.DataAnnotations;

namespace TallinnaRakendusLikKolledz.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<CourseAssigment>? CourseAssigments { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }
    }
}
