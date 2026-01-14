using System.ComponentModel.DataAnnotations;

namespace StempelApp.Viewmodels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bitte geben sie ihre E-Mail Adresse ein")]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

        [Required(ErrorMessage ="Bitte geben Sie Ihr Passwort ein")]
        public string Password { get; set; } = null!;
    }
}
