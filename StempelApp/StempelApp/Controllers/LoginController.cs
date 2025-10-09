using Microsoft.AspNetCore.Mvc;

namespace StempelApp.Controllers
{
    public class LoginController : Controller
    {
        // TODO:
        // change names of dbContext and User Model
        // private readonly RegisterLoginDbContext _context;
        //private readonly IPasswordHasher<Benutzer> _hasher;

        // TODO:
        // DI of _context and _hasher
        public LoginController() 
        {
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
