using Domain;
using DomainServices.Services;

namespace TGTG_Portal.ViewModels
{
    public class PacketViewModel
    {
        public Packet Packet { get; set; }

        public FormatterService fs = new FormatterService();
    }
}
