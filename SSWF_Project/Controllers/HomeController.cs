using Microsoft.AspNetCore.Mvc;

namespace TGTG_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("aanbod")]
        public IActionResult Packets()
        {
            return View("Packet-Overview");
        }

    }
}