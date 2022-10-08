using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasAlcohol { get; set; }

        [Required]
        public string? Image { get; set; }

        public ICollection<Packet>? Packets { get; set; }
    }
}
