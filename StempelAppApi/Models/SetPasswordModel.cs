using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StempelAppApi.Models
{
    public class SetPasswordModel
    {
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required] 
        public string Token { get; set; }

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
