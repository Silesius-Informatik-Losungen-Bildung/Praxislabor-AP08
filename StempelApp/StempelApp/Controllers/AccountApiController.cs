using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StempelApp.Viewmodels;
using System.Security.Claims;

namespace StempelApp.Controllers
{
    public class AccountApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration) : Controller
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly IConfiguration _config = configuration;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            if (await TryAppAdminLogin(model.Email, model.Password))
            {
                await SignInWithCookie(model.Email, "AppAdmin");
                Console.WriteLine("Eingeloggt!");
                return View("Login");
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                Console.WriteLine("Als User eingeloggt!");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Ungültige Email oder Passwort");
            Console.WriteLine("Passt nicht");
            return View("Error");
        }

        private async Task<bool> TryAppAdminLogin(string username, string password)
        {
            var superAdminEnabled = _config.GetValue<bool>("AppAdmin:Enabled", true);
            if (!superAdminEnabled) return false;

            var configUsername = _config["AppAdmin:Username"];
            var configPassword = _config["AppAdmin:Password"];

            return username == configUsername && password == configPassword;
        }

        private async Task SignInWithCookie(string username, string role)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            new Claim("AuthMethod", "AppAdmin")
        };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(identity));
        }

    }
}
