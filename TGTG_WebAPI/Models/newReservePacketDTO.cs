using System.ComponentModel.DataAnnotations;

namespace TGTG_WebAPI.Models
{
    public class newReservePacketDTO
    {
        [Required]
        public int PacketId { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
