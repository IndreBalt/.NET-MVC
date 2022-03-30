using InsurancePolicyRegistration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using User;

namespace InsurancePolicyRegistration.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<UserModel> _userServise;
        private readonly SignInManager<UserModel> _signInService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, ILogger<AuthController> logger)
        {
            _userServise = userManager;
            _signInService = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Registration");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(Registration model)
        {
            if (ModelState.IsValid && (model.Password == model.ConfirmPassword))
            {
                var newUser = new UserModel() { Email = model.Email, UserName = model.Name, FullName = model.Name };

                var result = await _userServise.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                {
                    await _signInService.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Login");
                }

                TempData["Errors"] = result.Errors.First().Description;

            }
            return View(model);
        }


        public IActionResult Login(string returnUrl = null)
        {
            _logger.LogInformation("Prisijungimas");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var myUser = await _userServise.FindByEmailAsync(model.Email);

                if (myUser != null)
                {
                    var result = await _signInService.PasswordSignInAsync(myUser, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index","Insurance");
                        }
                    }
                }
            }

            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInService.SignOutAsync();
            return Redirect("Index");
        }
    }
}
