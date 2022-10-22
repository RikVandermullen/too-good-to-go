using DomainServices;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TGTG_Portal.Controllers
{
    public class PacketController : Controller
    {
        private readonly IPacketRepository _packetRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICanteenRepository _canteenRepository;

        public PacketController(IPacketRepository packetRepository, IProductRepository productRepository, ICanteenRepository canteenRepository)
        {
            _packetRepository = packetRepository;
            _productRepository = productRepository;
            _canteenRepository = canteenRepository;
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
                ViewBag.MealTypeChoices = CreateMealTypeSelectList();
                ViewBag.CityChoices = CreateCitySelectList();
                ViewBag.LocationChoices = CreateLocationSelectList();
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePacket(Packet packet)
        {
            _packetRepository.UpdatePacket(packet);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult DeletePacket(int id)
        {
            _packetRepository.DeletePacket(id);
            return RedirectToAction("AdminPanel");
        }

        private SelectList CreateMealTypeSelectList()
        {
            return new SelectList(
                new List<SelectListItem> {
                new SelectListItem {Selected = false, Text = "Warm", Value = "WARM"},
                new SelectListItem {Selected = false, Text = "Brood", Value = "BROOD"},
                new SelectListItem {Selected = false, Text = "Gezond", Value = "GEZOND"},
                new SelectListItem {Selected = false, Text = "Dranken", Value = "DRANKEN"},
            }, "Value", "Text");
        }

        private SelectList CreateCitySelectList()
        {
            return new SelectList(
                new List<SelectListItem> {
                new SelectListItem {Selected = false, Text = "Breda", Value = "BREDA"},
                new SelectListItem {Selected = false, Text = "Tilburg", Value = "TILBURG"},
                new SelectListItem {Selected = false, Text = "Den Bosch", Value = "DENBOSCH"},
            }, "Value", "Text");
        }

        private SelectList CreateLocationSelectList()
        {
            Canteen[] choices = _canteenRepository.GetAllCanteens().ToArray();
            return new SelectList(choices, "Id", "Location");
        }
    }
}
