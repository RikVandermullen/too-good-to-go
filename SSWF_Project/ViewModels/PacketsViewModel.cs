using Domain;

namespace TGTG_Portal.ViewModels
{
    public class PacketsViewModel
    {
        public IEnumerable<Packet> Packets { get; set; } = Enumerable.Empty<Packet>();
    }
}
