using Domain;

namespace TGTG_Portal.ViewModels
{
    public class PacketProductsViewModel
    {
        public Packet Packet { get; set; } = null!;

        public IList<Product> Products { get; set; }
    }
}
