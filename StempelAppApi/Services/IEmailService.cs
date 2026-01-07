namespace StempelAppApi.Services
{
    public interface IEmailService
    {
        Task SendSetPasswordAsync(string email, string confirmationLink);
        Task SendPasswordResetAsync(string email, string resetLink);
    }
}
