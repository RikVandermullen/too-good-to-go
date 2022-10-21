using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    public class PacketController : Controller
    {
        private readonly IPacketRepository _packetRepository;
        private readonly IProductRepository _productRepository;

        public PacketController(IPacketRepository packetRepository, IProductRepository productRepository)
        {
            _packetRepository = packetRepository;
            _productRepository = productRepository;
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

        public IActionResult AdminPanel()
        {
            var packets = _packetRepository.GetPackets();
            var products = _productRepository.GetProducts();
            if (packets != null && products != null)
            {
                var viewModel = new PacketsProductsViewModel
                {
                    Packets = packets,
                    Products = products
                };
                return View(viewModel);
            }
            return View();
        }
    }
}
