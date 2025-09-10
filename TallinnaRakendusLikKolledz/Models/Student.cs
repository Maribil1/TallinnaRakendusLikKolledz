
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakendusLikKolledz.Models
{
    
    
       public class Student
        {
            [Key]
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime EnrollmentDate { get; set; }
        }
    
}
