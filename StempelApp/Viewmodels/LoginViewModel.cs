using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StempelApp.Viewmodels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
        [Required(ErrorMessage = "E-Mail-Adresse ist erforderlich.")]
        public string Email { get; set; } = null!;

        [PasswordPropertyText]
        [Required(ErrorMessage = "Passwort ist erforderlich.")]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
