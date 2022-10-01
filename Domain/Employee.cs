using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Employee : Person
    {
        [Key]
        public int EmployeeNumber { get; set; }

        [Required]
        public Canteen? Canteen { get; set; }
    }
}
