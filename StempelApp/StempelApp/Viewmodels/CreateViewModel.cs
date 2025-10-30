using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StempelApp.Viewmodels
{
    public class CreateViewModel
    {
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
        [Required(ErrorMessage = "E-Mail-Adresse ist erforderlich.")]
        public string Email { get; set; } = null!;
    }
}
