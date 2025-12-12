using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StempelApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "appAdmin")]
        public async Task<IActionResult> Dashboard()
        {
            return View("DashboardAppAdmin");
        }
    }
}
