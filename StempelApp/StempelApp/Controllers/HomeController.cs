using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StempelApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var role = User.Claims
                        .FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

            switch (role)
            {
                case "appAdmin":
                    return View("DashboardAppAdmin");

                case "cleaningAdmin":
                    return View("DashboardCleaningAdmin");

                case "cleaningStaff":
                    return View("DashboardCleaningStaff");

                case "buildingOwner":
                    return View("DashboardBuildingOwner");
                
                default:
                    return View("Index");
            }
        }

        [Authorize(Roles = "appAdmin")]
        public IActionResult DashboardAppAdmin()
        {
            return View();
        }

        [Authorize(Roles = "cleaningAdmin")]
        public IActionResult DashboardCleaningAdmin()
        {
            return View();
        }

        [Authorize(Roles = "cleaningStaff")]
        public IActionResult DashboardCleaningStaff()
        {
            return View();
        }

        [Authorize(Roles = "buildingOwner")]
        public IActionResult BuildingOwner()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
