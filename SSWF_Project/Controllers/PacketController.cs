using DomainServices;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (id == null)
            {
                var packets = _packetRepository.GetPacketsWithoutReservations();
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

        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult AdminPanel()
        {
            var packets = _packetRepository.GetPackets();
            var products = _productRepository.GetProducts();
            var employee = _employeeRepository.GetEmployeeByEmail(User.Identity.Name);
            ViewBag.PacketError = TempData["InvalidPacket"];
            if (packets != null && products != null)
            {
                var viewModel = new EmployeePacketsProductsViewModel
                {
                    Employee = employee,
                    Packets = packets,
                    Products = products
                };
                ViewBag.MealTypeChoices = CreateMealTypeSelectList(employee.Canteen);
                ViewBag.CityChoices = CreateCitySelectList(employee.Canteen.City);
                ViewBag.AllCityChoices = CreateAllCitySelectList();
                ViewBag.LocationChoices = CreateLocationSelectList(employee.Canteen.City);
                ViewBag.AllLocationChoices = CreateAllLocationSelectList();
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
                ViewBag.MealTypeChoices = CreateMealTypeSelectList(employee.Canteen);
                ViewBag.CityChoices = CreateCitySelectList(employee.Canteen.City);
                ViewBag.AllCityChoices = CreateAllCitySelectList();
                ViewBag.LocationChoices = CreateLocationSelectList(employee.Canteen.City);
                ViewBag.AllLocationChoices = CreateAllLocationSelectList();
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
            await _packetRepository.UpdatePacket(packet);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize(Policy = "OnlyPowerUsersAndUp")]
        public IActionResult DeletePacket(int id)
        {
            _packetRepository.DeletePacket(id);
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

            if (Packet.DoesPacketContainAlcohol())
            {
                if (Student.IsStudentOfAge())
                {
                    _packetRepository.ReservePacket(id, Student);
                } else
                {
                    TempData["OfAge"] = "Geen 18";
                    return RedirectToAction("Packets", new {id = id});
                }
            } else
            {
                _packetRepository.ReservePacket(id, Student);
            }
            
            return RedirectToAction("Packets");
        }

        private SelectList CreateMealTypeSelectList(Canteen canteen)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem {Selected = false, Text = "Dranken", Value = "DRANKEN"},
                new SelectListItem {Selected = false, Text = "Brood", Value = "BROOD"},
                new SelectListItem {Selected = false, Text = "Gezond", Value = "GEZOND"},
            };
            if (canteen.WarmMeals)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Warm", Value = "WARM" });
            }

            return new SelectList(list, "Value", "Text");
        }

        private SelectList CreateCitySelectList(City city)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (city == City.BREDA)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Breda", Value = "BREDA" });
            } else if (city == City.TILBURG)
            {
                list.Add(new SelectListItem { Selected = false, Text = "Tilburg", Value = "TILBURG" });
            } else
            {
                list.Add(new SelectListItem { Selected = false, Text = "Den Bosch", Value = "DENBOSCH" });
            }
            return new SelectList(list, "Value", "Text");
        }

        private SelectList CreateAllCitySelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Selected = false, Text = "Breda", Value = "BREDA" });
            list.Add(new SelectListItem { Selected = false, Text = "Tilburg", Value = "TILBURG" });
            list.Add(new SelectListItem { Selected = false, Text = "Den Bosch", Value = "DENBOSCH" });

            return new SelectList(list, "Value", "Text");
        }

        private SelectList CreateLocationSelectList(City city)
        {
            List<Canteen> list = _canteenRepository.GetAllCanteens().Where(l => l.City == city).ToList();
            return new SelectList(list, "Id", "Location");
        }

        private SelectList CreateAllLocationSelectList()
        {
            List<Canteen> list = _canteenRepository.GetAllCanteens().ToList();
            return new SelectList(list, "Id", "Location");
        }
    }
}
