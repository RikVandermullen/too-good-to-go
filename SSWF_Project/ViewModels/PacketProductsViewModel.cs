using Domain;
using System.ComponentModel.DataAnnotations;

namespace TGTG_Portal.ViewModels
{
    public class PacketProductsViewModel
    {
        public Packet Packet { get; set; } = null!;

        public IList<Product> Products { get; set; }
    }
}
