using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StempelApp.Viewmodels;
using StempelAppCore.Data;

namespace StempelApp.Controllers
{
    public class DashboardController : Controller
    {

        private readonly StempelAppContext _context;

        public DashboardController(StempelAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            var model = new KontaktViewModel();

            // Daten laden mit Include!
            model.Mitarbeiter = _context.Users
                .Include(u => u.ContactInfo) // Ohne das ist ContactInfo NULL
                .Where(u => u.UserTypeId != 10)
                .ToList();

            model.Immobilienbesitzer = _context.Customers
                .Include(c => c.User)
                    .ThenInclude(u => u.ContactInfo)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Address) // <--- Füge das noch hinzu!
                .ToList();

            return View(model); // <--- Das 'model' MUSS hier stehen!
        }

        public IActionResult Revenue()
        {
            return View();
        }

        public IActionResult NewRequests()
        {
            return View();
        }

        public IActionResult OpenProjects()
        {
            return View();
        }
    }
}
