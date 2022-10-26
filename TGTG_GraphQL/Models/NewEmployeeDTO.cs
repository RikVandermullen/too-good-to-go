using System.ComponentModel.DataAnnotations;

namespace TGTG_GraphQL.Models
{
    public class NewEmployeeDTO
    {
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
