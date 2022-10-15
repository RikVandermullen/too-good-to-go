using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [ForeignKey("Canteen")]
        public int Canteen { get; set; }
    }
}
