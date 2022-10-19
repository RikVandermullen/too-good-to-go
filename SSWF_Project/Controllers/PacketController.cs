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
        [Route("packets")]
        public IActionResult Packets()
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
    }
}
