using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Student : Person
    {
        [Key]
        public int StudentNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        public City City { get; set; }

        public int noShows { get; set; }
    }
}
