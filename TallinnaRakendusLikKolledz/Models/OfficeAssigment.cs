using System.ComponentModel.DataAnnotations;

namespace TallinnaRakendusLikKolledz.Models
{
    public class OfficeAssigment
    {
        [Key]
        public int InstructorID{ get; set; }
        public Instructor Instructor { get; set; }
        [StringLength(50)]
        [Display(Name ="Kabinet")]
        public string Location {  get; set; }
    }
}
