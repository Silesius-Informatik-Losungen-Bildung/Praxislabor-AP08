using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StempelApp.Controllers
{
    public class AccountController : ControllerBase
    {
        // TODO:
        // change names of dbContext and User Model
        // private readonly RegisterLoginDbContext _context;
        //private readonly IPasswordHasher<Benutzer> _hasher;

        // TODO:
        // DI of _context and _hasher
        public AccountController() 
        {
        }
        public IActionResult Register()
        {
            //return Ok;
        }
        public IActionResult Login()
        {
            //return Ok;
        }
    }
}
