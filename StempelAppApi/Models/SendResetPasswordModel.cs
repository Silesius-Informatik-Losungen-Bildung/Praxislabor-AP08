using System.ComponentModel.DataAnnotations;

namespace StempelAppApi.Models
{
    public class SendResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
