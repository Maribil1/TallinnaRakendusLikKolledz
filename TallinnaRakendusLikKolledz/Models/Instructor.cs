﻿using System.ComponentModel.DataAnnotations;


namespace TallinnaRakendusLikKolledz.Models
{
    public class Instructor 
    {
        [Key]
        public int ID{ get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName{ get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string FirstName { get; set; }

        [Display(Name = "Õpetaja nimi")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [Display (Name = "Tööleasumiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssigment>? CourseAssigments { get; set; }
        public OfficeAssigment? OfficeAssigments { get; set; }
        
        [Display(Name = "Vanus")]
        public int? Age { get; set; }
        [Display(Name = "Sugu")]
        public string? Gender { get; set; }
        [Display(Name = "Abiellu staatus")]
        public string? MartialStatus { get; set; }
    }
}
