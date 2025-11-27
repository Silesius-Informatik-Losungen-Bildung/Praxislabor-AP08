using Microsoft.AspNetCore.Mvc;
using StempelApp.Viewmodels;
using System.Text.Json;

namespace StempelApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AccountApi");
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
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

            //Anfrage an Api
            var loginData = new
            {
                email = loginViewModel.Email,
                password = loginViewModel.Password
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5209/accountapi/login", loginData);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard");
            }
            return View(loginViewModel);
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
                ViewBag.SuccessMessage = "E-Mail wurde gesendt, bitte prüfen Sie Ihr Postfach zur Bestätigung.";

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


        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
