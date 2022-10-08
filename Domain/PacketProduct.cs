using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PacketProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Packet Packet { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
