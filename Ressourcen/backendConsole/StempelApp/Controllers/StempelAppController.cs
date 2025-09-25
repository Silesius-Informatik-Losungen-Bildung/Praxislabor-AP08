using Microsoft.AspNetCore.Mvc;

namespace StempelApp.WebControllers
{
    public class StempelAppController : Controller
    {
        private readonly ILogger<StempelAppController> _logger;

        public StempelAppController(ILogger<StempelAppController> logger)
        {
            _logger = logger;
        }
        public IActionResult UserHomepage()
        {
            return View();
        }
    }
}
