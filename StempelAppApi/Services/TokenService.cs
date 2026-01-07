using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace StempelAppApi.Services
{
    public class TokenService(IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        public  async Task<string> getPasswordLink(IdentityUser user)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            var baseUrl = configuration["AppSettings:BaseUrl"];
            var setPasswordLink = $"{baseUrl}/AccountApi/SetPassword?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(encodedToken)}";

            return setPasswordLink;
        }
    }
}
