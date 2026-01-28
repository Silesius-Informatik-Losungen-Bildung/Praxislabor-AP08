using System.ComponentModel.DataAnnotations;

namespace StempelApp.Viewmodels
{
    public class ResetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
        [Required(ErrorMessage = "E-Mail-Adresse ist erforderlich.")]
        public string Email { get; set; } = null!;
    }
}
