using Domain;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    [Authorize(Policy = "OnlyRegularUsersAndUp")]
    public class HomeController : Controller
    {
        private readonly IPacketRepository _packetRepository;

        public HomeController(IPacketRepository packetRepository)
        {
            _packetRepository = packetRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("aanbod")]
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