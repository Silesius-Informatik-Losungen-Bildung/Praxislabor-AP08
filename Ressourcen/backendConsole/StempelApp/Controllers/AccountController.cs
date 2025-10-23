using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StempelApp.Viewmodels;
using StempelAppCore.Data;

namespace StempelApp.Controllers
{
    public class AccountController(ILogger<AccountController> logger, StempelAppContext context) : Controller
    {
        private readonly ILogger<AccountController> _logger = logger;
        private readonly StempelAppContext _context = context;

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.Include(c => c.ContactInfo)
            .FirstOrDefault(u => u.ContactInfo.Email == model.UserEmail && u.PasswordHash == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "E-Mail oder Passwort ist ungültig.");
                return View(model);
            }

            return RedirectToAction("UserHomepage", "StempelApp", new { userEmail = user.ContactInfo.Email });
        }
    }
}
