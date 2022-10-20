using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    public class PacketController : Controller
    {
        private readonly IPacketRepository _packetRepository;

        public PacketController(IPacketRepository packetRepository)
        {
            _packetRepository = packetRepository;
        }

        [AllowAnonymous]
        [Route("packets/{id?}")]
        public IActionResult Packets(int? id)
        {
            if (id == null)
            {
                var packets = _packetRepository.GetPackets();
                if (packets != null)
                {
                    var viewModel = new PacketsViewModel
                    {
                        Packets = packets
                    };
                    return View("Packet-Overview", viewModel);
                }
                return View("Packet-Overview");
            }

            var Packet = _packetRepository.GetPacketById((int)id);
            return View("Packet-Detail", Packet);
        }
    }
}
