
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakendusLikKolledz.Models
{
    
    
       public class Student
        {
            [Key]
            public int ID { get; set; }
            public  string FirstName { get; set; }
            public  string LastName { get; set; }
            public DateTime EnrollmentDate { get; set; }
            public ICollection<Enrollment>? Enrollments { get; set; }

            public int? Age { get; set; }
            public int ? Birthday { get; set; }
            public string? Gender { get; set;}

       }

}
