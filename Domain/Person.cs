
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class Person
    {
        [Required]
        [StringLength(50)]
        public string? EmailAddress { get; set; }

        [Required]
        public int? Number { get; set; }

        [Required]
        [StringLength(30)]
        public string? Password { get; set; }
    }
}
