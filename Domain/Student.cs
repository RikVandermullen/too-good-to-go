using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public int StudentNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string? City { get; set; }

        public int noShows { get; set; }
    }
}
