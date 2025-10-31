using System.ComponentModel.DataAnnotations;

namespace StempelAppApi.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
