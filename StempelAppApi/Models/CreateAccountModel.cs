using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StempelAppApi.Models
{
    public class CreateAccountModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
