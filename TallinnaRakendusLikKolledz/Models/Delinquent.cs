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
        public string? InCourt { get; set; }
        public string? Solved { get; set; }
        public string? Dropped { get; set; }
        public string? Solving { get; set; }
        public string? PoliceInvolved {  get; set; }

    }
}
