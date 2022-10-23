using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasAlcohol { get; set; }

        [Required]
        public string? Image { get; set; }

        public ICollection<Packet> Packets { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
