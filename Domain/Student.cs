using System.ComponentModel.DataAnnotations;


namespace Domain
{
    public class Student : Person
    {
        [Key]
        public int StudentNumber { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public City City { get; set; }

        public int noShows { get; set; }

    }
}
