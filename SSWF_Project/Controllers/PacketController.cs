using DomainServices;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using DomainServices.Services;
using TGTG_Portal.Extensions;
using TGTG_EF;

namespace TGTG_Portal.Controllers
{
    [Authorize(Policy= "OnlyRegularUsersAndUp")]
    public class PacketController : Controller
    {
        private readonly IPacketRepository _packetRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICanteenRepository _canteenRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public PacketController(IPacketRepository packetRepository, IProductRepository productRepository, ICanteenRepository canteenRepository, IStudentRepository studentRepository, IEmployeeRepository employeeRepository)
        {
            _packetRepository = packetRepository;
            _productRepository = productRepository;
            _canteenRepository = canteenRepository;
            _studentRepository = studentRepository;
            _employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        [Route("packets/{id?}")]
        public IActionResult Packets(int? id)
        {
            ViewBag.ErrorMessage = TempData["OfAge"];
            ViewBag.ReserveError = TempData["ReserveError"];
            ViewBag.Reserved = TempData["Reserved"];
            if (id == null)
            {
                var packets = _packetRepository.GetPacketsWithoutReservations();
                if (packets != null)
                {
                    var viewModel = new PacketsViewModel
                    {
                        Packets = packets,
                        fs = new FormatterService()
                    };
                    return View("Packet-Overview", viewModel);
                }
                return View("Packet-Overview");
            }

            var Packet = _packetRepository.GetPacketById((int)id);
            var vm = new PacketViewModel
            {
                Packet = Packet
            };
            return View("Packet-Detail", vm);
        }

        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult AdminPanel()
        {
            var packets = _packetRepository.GetPackets();
            var products = _productRepository.GetProducts();
            var employee = _employeeRepository.GetEmployeeByEmail(User.Identity.Name);
            if (TempData["InvalidPacket"] != null)
            {
                ViewBag.PacketError = TempData["InvalidPacket"];
            }
            if (packets != null && products != null)
            {
                var viewModel = new EmployeePacketsProductsViewModel
                {
                    Employee = employee,
                    Packets = packets,
                    Products = products
                };
                SelectListCreator listCreator = new SelectListCreator();

                ViewBag.MealTypeChoices = listCreator.MealTypeSelectList(employee.Canteen);
                ViewBag.CityChoices = listCreator.CitySelectList(employee.Canteen.City);
                ViewBag.AllCityChoices = listCreator.AllCitySelectList();

                List<Canteen> list = _canteenRepository.GetAllCanteens().Where(l => l.City == employee.Canteen.City).ToList();
                ViewBag.LocationChoices = listCreator.LocationSelectList(list,employee.Canteen.City);
                ViewBag.AllLocationChoices = listCreator.AllLocationSelectList(list);
                return View(viewModel);
            }
            return View();
        }

        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult AdminPanelKantine()
        {
            var products = _productRepository.GetProducts();
            var employee = _employeeRepository.GetEmployeeByEmail(User.Identity.Name);
            var packets = _packetRepository.GetPacketsByCanteenId(employee.CanteenId);
            ViewBag.PacketError = TempData["InvalidPacket"];
            if (packets != null && products != null)
            {
                var viewModel = new EmployeePacketsProductsViewModel
                {
                    Employee = employee,
                    Packets = packets,
                    Products = products
                };

                SelectListCreator listCreator = new SelectListCreator();
                ViewBag.MealTypeChoices = listCreator.MealTypeSelectList(employee.Canteen);
                ViewBag.CityChoices = listCreator.CitySelectList(employee.Canteen.City);
                ViewBag.AllCityChoices = listCreator.AllCitySelectList();

                List<Canteen> list = _canteenRepository.GetAllCanteens().Where(l => l.City == employee.Canteen.City).ToList();
                ViewBag.LocationChoices = listCreator.LocationSelectList(list, employee.Canteen.City);
                ViewBag.AllLocationChoices = listCreator.AllLocationSelectList(list);
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public async Task<IActionResult> UpdatePacket(Packet packet)
        {
            if (!ModelState.IsValid)
            {
                TempData["InvalidPacket"] = "Sommige velden waren onjuist of niet ingevoerd. Pakket is niet gewijzigd";
                return RedirectToAction("AdminPanel");
            }

            List<Product> ProductsToAdd = packet.Products.Where(p => p.IsChecked).ToList();
            packet.Products = ProductsToAdd;
            packet.PickUpTime = new DateTime(packet.PickUpTime.Value.Year, packet.PickUpTime.Value.Month, packet.PickUpTime.Value.Day, 0, 0, 0);
            packet.LastestPickUpTime = packet.PickUpTime.Value.AddHours(packet.LastestPickUpTime.Value.Hour);

            var AlcoholCheck = new ReservePacketService().DoesProductsInPacketContainAlcohol(packet);
            packet.ContainsAlcohol = AlcoholCheck;

            await _packetRepository.UpdatePacket(packet);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult DeletePacket(Packet packet)
        {
            _packetRepository.DeletePacket(packet.Id);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult CreatePacket(Packet packet)
        {
            if (!ModelState.IsValid)
            {
                TempData["InvalidPacket"] = "Sommige velden waren onjuist of niet ingevoerd. Pakket is niet aangemaakt.";
                return RedirectToAction("AdminPanel");
            }

            List<Product> ProductsToAdd = packet.Products.Where(p => p.IsChecked).ToList();
            packet.Products = ProductsToAdd;
            packet.PickUpTime = new DateTime(packet.PickUpTime.Value.Year, packet.PickUpTime.Value.Month, packet.PickUpTime.Value.Day, 0, 0, 0);
            packet.LastestPickUpTime = packet.PickUpTime.Value.AddHours(packet.LastestPickUpTime.Value.Hour);

            var AlcoholCheck = new ReservePacketService().DoesProductsInPacketContainAlcohol(packet);
            packet.ContainsAlcohol = AlcoholCheck;

            _packetRepository.AddPacket(packet);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult ReservePacket(int id)
        {
            var Student = _studentRepository.GetStudentByEmail(User.Identity.Name);
            var Packet = _packetRepository.GetPacketById(id);
            int packets = _packetRepository.GetPacketsByStudentId(Student).Where(date => date.PickUpTime == Packet.PickUpTime).Count();
            if (packets > 0)
            {
                TempData["ReserveError"] = "1";
                return RedirectToAction("Packets", new { id = id });
            }

            ReservePacketService reservePacketService = new ReservePacketService(new StudentOfAgeService(Student));

            if (reservePacketService.CanStudentReservePacket(Packet, Student))
            {
                _packetRepository.ReservePacket(id, Student);
                TempData["Reserved"] = "true";
                return RedirectToAction("Packets", new { id = id });
            }

            TempData["OfAge"] = "Geen 18";
            return RedirectToAction("Packets", new { id = id });
        }
    }
}
