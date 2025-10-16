using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StempelApp.Controllers
{
    public class AccountApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration) : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly IConfiguration _config = configuration;
    }
}
