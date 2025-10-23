using Microsoft.AspNetCore.Mvc;

namespace StempelApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
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
