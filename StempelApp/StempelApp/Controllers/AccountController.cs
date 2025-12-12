using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StempelApp.Viewmodels;
using System.Text.Json;

namespace StempelApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IHttpClientFactory httpClientFactory, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _httpClient = httpClientFactory.CreateClient("AccountApi");
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Account");
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SetPassword(string email, string token)
        {
            var model = new SetPasswordViewModel
            {
                Email = email,
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var setPasswordData = new
            {
                email = model.Email,
                token = model.Token,
                newPassword = model.Password
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5209/AccountApi/SetPassword", setPasswordData);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Passwort erfolgreich erstellt! Sie können sich jetzt anmelden.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Fehler beim Erstellen des Passworts");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            // ✅ DIREKT mit WebApp Identity anmelden (KEIN API-Call!)
            var result = await _signInManager.PasswordSignInAsync(
                loginViewModel.Email,
                loginViewModel.Password,
                isPersistent: true,  // "Angemeldet bleiben"
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Console.WriteLine($"✅ Login erfolgreich: {loginViewModel.Email}");
                return RedirectToAction("Dashboard");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account vorübergehend gesperrt.");
            }
            else if (result.RequiresTwoFactor)
            {
                ModelState.AddModelError("", "Zwei-Faktor-Authentifizierung erforderlich.");
            }
            else
            {
                ModelState.AddModelError("", "Ungültige Anmeldedaten.");
                // Bei falschem Passwort: Lockout-Zähler erhöhen
                await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, true);
            }

            return View(loginViewModel);
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }

            var createData = new
            {
                email = createViewModel.Email
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5209/accountapi/create", createData);

            if (response.IsSuccessStatusCode)
            {
                // Success-Message für die View setzen
                ViewBag.SuccessMessage = "E-Mail wurde gesendet, bitte prüfen Sie Ihr Postfach zur Bestätigung.";

                // Model zurücksetzen, damit das Formular leer ist
                var emptyModel = new CreateViewModel();
                return View(emptyModel);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var error = JsonSerializer.Deserialize<JsonElement>(errorContent);

                    if (error.TryGetProperty("message", out var message))
                    {
                        ModelState.AddModelError("", message.GetString() ?? "Registrierung fehlgeschlagen");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Registrierung fehlgeschlagen");
                }
            }
            else
            {
                ModelState.AddModelError("", "Registrierung fehlgeschlagen");
            }

            return View(createViewModel);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }

            var resetData = new
            {
                email = resetPasswordViewModel.Email
            };

            var response = await _httpClient.PostAsJsonAsync("AccountApi/SendResetPasswordEmail", resetData);

            if (response.IsSuccessStatusCode)
            {
                // Success-Message für die View setzen
                ViewBag.SuccessMessage = "E-Mail wurde gesendet, bitte prüfen Sie Ihr Postfach zur Bestätigung.";

                // Model zurücksetzen, damit das Formular leer ist
                var emptyModel = new ResetPasswordViewModel();
                return View(emptyModel);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var error = JsonSerializer.Deserialize<JsonElement>(errorContent);

                    if (error.TryGetProperty("message", out var message))
                    {
                        ModelState.AddModelError("", message.GetString() ?? "Passwort reset fehlgeschlagen");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Passwort reset fehlgeschlagen");
                }
            }
            else
            {
                ModelState.AddModelError("", "Passwort reset fehlgeschlagen");
            }

            return View(resetPasswordViewModel);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            return View("DashboardAppAdmin");
        }



    }
}
