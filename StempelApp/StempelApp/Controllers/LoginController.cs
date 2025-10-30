using Microsoft.AspNetCore.Mvc;
using StempelApp.Viewmodels;
using System.Text.Json;

namespace StempelApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(IHttpClientFactory httpClientFactory)
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

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
