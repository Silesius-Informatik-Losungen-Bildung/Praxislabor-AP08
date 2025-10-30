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

            //var loginDataJson = JsonSerializer.Serialize(loginData);
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5209/accountapi/login", loginData);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard");
            }
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var registerData = new
            {
                email = registerViewModel.Email,
                password = registerViewModel.Password
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5209/accountapi/register", registerData);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Registrierung erfolgreich! Bitte prüfen Sie Ihre E-Mails zur Bestätigung.";
                return RedirectToAction("Login"); 
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

            return View(registerViewModel);
        }


        //[HttpGet]
        //public IActionResult Dashboard()
        //{
        //    return View();
        //}

    }
}
