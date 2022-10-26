using System.ComponentModel.DataAnnotations;

namespace TGTG_GraphQL.Models
{
    public class NewStudentDTO
    {
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
