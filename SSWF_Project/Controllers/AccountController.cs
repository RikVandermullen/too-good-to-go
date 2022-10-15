using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel vm)
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

            return RedirectToAction("index", "home");

        }

    }
}
