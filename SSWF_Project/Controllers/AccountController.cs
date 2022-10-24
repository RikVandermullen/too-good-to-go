using DomainServices;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPacketRepository _packetRepository;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IStudentRepository studentRepository, IPacketRepository packetRepository, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentRepository = studentRepository;
            _packetRepository = packetRepository;
            _employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByNameAsync(vm.EmailAddress);
            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect emailaddress or password or account is locked");
                return View();
            }

            var signinResult = await _signInManager.PasswordSignInAsync(user, vm.Password, true, false);

            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect emailaddress or password or account is locked");
                return View();
            }

            return RedirectToAction("Profile");

        }

        [Authorize(Policy = "OnlyRegularUsersAndUp")]
        public IActionResult Profile()
        {
            if (User != null)
            {
                var claim = User.Claims.ToList().ElementAt(3).ToString();
                if (claim.Equals("UserType: regularuser")) {
                    var Student = _studentRepository.GetStudentByEmail(User.Identity.Name)!;
                    IEnumerable<Packet> Packets = _packetRepository.GetPacketsByStudentId(Student!)!;
                    return View(new StudentPacketsViewModel(Student, Packets));
                }
                else
                {
                    var Employee = _employeeRepository.GetEmployeeByEmail(User.Identity.Name);
                    return View("Employee-Profile", Employee);
                }
                
                
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
