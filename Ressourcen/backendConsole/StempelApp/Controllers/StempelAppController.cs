using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StempelApp.Viewmodels;
using StempelAppCore.Data;

namespace StempelApp.Controllers
{
    public class StempelAppController(ILogger<StempelAppController> logger, StempelAppContext context) : Controller
    {
        private readonly ILogger<StempelAppController> _logger = logger;
        private readonly StempelAppContext _context = context;

        [HttpGet]
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
                    StartTime = p.StartTime,
                    Activities = p.Activities.ToList()
                })
                .ToList();

            var viewModel = new UserViewModel
            {
                UserEmail = userEmail,
                Projects = projects
            };

            return View(viewModel);
        }

        [HttpGet]

        public IActionResult WorkList(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Login", "StempelApp");

            var user = _context.Users.Include(c => c.ContactInfo)
                .FirstOrDefault(u => u.ContactInfo.Email == userEmail);
            if (user == null)
                return RedirectToAction("Login", "StempelApp");

            var projects = _context.Projects
                .Where(p => p.CleaningPersonnel.Any(u => u.Id == user.Id))
                .Select(p => new ProjectInfo
                {
                    Activities = p.Activities.ToList()
                })
                .ToList();

            var viewModel = new UserViewModel
            {
                Projects = projects
            };

            return View(viewModel);
        }

    }
}