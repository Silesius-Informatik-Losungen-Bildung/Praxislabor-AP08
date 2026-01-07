using System.ComponentModel.DataAnnotations;

namespace StempelApp.Viewmodels
{
    public class SetPasswordViewModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Token { get; set; } = null!;

        [Required(ErrorMessage = "Passwort ist erforderlich.")]
        [MinLength(6, ErrorMessage = "Passwort muss mindestens 6 Zeichen lang sein.")]
        [Display(Name = "Passwort")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Passwort-Bestätigung ist erforderlich.")]
        [Compare("Password", ErrorMessage = "Passwort und Bestätigung stimmen nicht überein.")]
        [Display(Name = "Passwort bestätigen")]
        public string ConfirmPassword { get; set; } = null!;
    }
}