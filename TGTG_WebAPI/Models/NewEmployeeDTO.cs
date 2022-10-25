using System.ComponentModel.DataAnnotations;

namespace TGTG_WebAPI.Models
{
    public class NewEmployeeDTO
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public int CanteenId { get; set; }
    }
}
