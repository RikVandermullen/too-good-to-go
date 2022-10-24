using Domain;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}