using System.ComponentModel.DataAnnotations;

namespace TallinnaRakendusLikKolledz.Models
{
    public enum Violations
    {
        Stealing,Scamming, Assault, SevereAssault, VerbalAssault
    }
    public enum Job
    {
        Student, Instructor
    }

    public class Delinquent
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violations? Violation {  get; set; }
        public Job? Position { get; set; }
        public Boolean? InCourt { get; set; }
        public Boolean? Solved { get; set; }
        public Boolean? Dropped { get; set; }
        public Boolean? Solving { get; set; }
        public Boolean? PoliceInvolved {  get; set; }

    }
}
