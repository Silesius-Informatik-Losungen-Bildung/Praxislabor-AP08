
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using StempelAppApi.Models;
using StempelAppApi.Services;
using System.Security.Claims;
using System.Text;

namespace StempelApp.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IEmailService emailService) : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly IConfiguration _configuration = configuration;
        private readonly IEmailService _emailService = emailService;


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // Prüfen ob Email bestätigt wurde
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    return Unauthorized(new
                    {
                        Success = false,
                        Message = "Bitte bestätigen Sie zuerst Ihre E-Mail-Adresse.",
                        RequireEmailConfirmation = true
                    });
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Login erfolgreich",
                        UserId = user.Id,
                        Email = user.Email
                    });
                }
            }

            return Unauthorized(new { Success = false, Message = "Ungültige Anmeldedaten" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountModel model)
        {
            // Prüfen ob Email bereits existiert
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { Success = false, Message = "Email bereits vorhanden." });
            }

            // User OHNE Passwort erstellen
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = false // Wichtig: Noch nicht bestätigt
            };

            // User OHNE Passwort erstellen
            var result = await _userManager.CreateAsync(user); // Kein Password!

            if (result.Succeeded)
            {
                // Password-Reset-Token für erste Passwort-Erstellung verwenden
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var baseUrl = _configuration["AppSettings:BaseUrl"];
                var setPasswordLink = $"{baseUrl}/accountapi/set-password?Email={user.Email}&Token={encodedToken}";

                // Email mit "Passwort erstellen"-Link senden
                await _emailService.SendSetPasswordAsync(user.Email, setPasswordLink);

                return Ok(new
                {
                    Success = true,
                    Message = "Registrierung erfolgreich. Bitte prüfen Sie Ihre E-Mails um Ihr Passwort zu erstellen."
                });
            }

            return BadRequest(new { Success = false, Errors = result.Errors });
        }

        [HttpGet] //todo
        public IActionResult SetPassword([FromQuery] string email, [FromQuery] string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return BadRequest(new { message = "email und token sind erforderlich" });

            var webAppUrl = _configuration["AppSettings:WebUrl"]; // z. B. https://localhost:5136
            var target = $"{webAppUrl}/Account/SetPassword?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";
            return Redirect(target); // 302 Redirect zur WebApp-View
        }

        [HttpPost]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new { Success = false, Message = "Benutzer nicht gefunden" });

            string decoded;
            try
            {
                decoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            }
            catch
            {
                return BadRequest(new { Success = false, Message = "Ungültiger Token" });
            }

            var result = await _userManager.ResetPasswordAsync(user, decoded, model.NewPassword);
            if (result.Succeeded)
            {
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                return Ok(new { Success = true, Message = "Passwort erfolgreich erstellt" });
            }

            return BadRequest(new { Success = false, Errors = result.Errors });
        }

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        return BadRequest(new { Success = false, Message = "Ungültige Anfrage" });
        //    }

        //    var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
        //    var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

        //    if (result.Succeeded)
        //    {
        //        return Ok(new { Success = true, Message = "Passwort erfolgreich zurückgesetzt" });
        //    }

        //    return BadRequest(new { Success = false, Errors = result.Errors });
        //}
    }
}
