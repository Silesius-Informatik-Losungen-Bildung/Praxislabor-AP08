using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StempelApp.Viewmodels;
using StempelAppCore.Data;

namespace StempelApp.WebControllers
{
    public class StempelAppController : Controller
    {
        private readonly ILogger<StempelAppController> _logger;
        private readonly StempelAppContext _context;

        public StempelAppController(ILogger<StempelAppController> logger, StempelAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult UserHomepage(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "StempelApp");

            var user = _context.Users.Include(u => u.ContactInfo)
                .FirstOrDefault(u => u.ContactInfo.Email == userEmail);
            if (user == null)
                return RedirectToAction("Login", "StempelApp");

            var projects = _context.Projects
                .Where(p => p.CleaningPersonnel.Any(u => u.Id == user.Id))
                .Select(p => new ProjectInfo
                {
                    CustomerName = p.CustomerName,
                    Address = p.Address.StreetHouseNr + ", " + p.Address.City,
                    StartTime = p.StartTime
                })
                .ToList();

            var viewModel = new UserHomepageViewModel
            {
                Projects = projects
            };

            return View(viewModel);
        }

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

                        var user = _context.Users.Include(c=> c.ContactInfo)
                .FirstOrDefault(u => u.ContactInfo.Email == model.UserEmail && u.PasswordHash == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "E-Mail oder Passwort ist ungültig.");
                return View(model);
            }

            // Weiterleitung mit Übergabe der E-Mail als Parameter
            return RedirectToAction("UserHomepage", "StempelApp", new { userEmail = user.ContactInfo.Email });
        }

        public IActionResult AufgabenListe()
        {
            return View();
        }
    }
}