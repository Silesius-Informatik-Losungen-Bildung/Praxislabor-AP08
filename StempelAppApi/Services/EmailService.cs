using System.Net;
using System.Net.Mail;

namespace StempelAppApi.Services
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task SendSetPasswordAsync(string email, string setPasswortLink)
        {
            var subject = "E-Mail-Adresse bestätigen";
            var body = $@"
            <h2>Willkommen!</h2>
            <p>Bitte bestätigen Sie Ihre E-Mail-Adresse, indem Sie auf den folgenden Link klicken:</p>
            <p><a href='{setPasswortLink}'>E-Mail bestätigen</a></p>
            <p>Oder kopieren Sie diesen Link in Ihren Browser:</p>
            <p>{setPasswortLink}</p>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetAsync(string email, string resetLink)
        {
            {
                var subject = "Passwort zurücksetzen";
                var body = $@"
                <h2>Passwort zurücksetzen</h2>
                <p>Sie haben eine Passwort-Zurücksetzung angefordert. Klicken Sie auf den folgenden Link:</p>
                <p><a href='{resetLink}'>Neues Passwort erstellen</a></p>
                <p>Oder kopieren Sie diesen Link in Ihren Browser:</p>
                <p>{resetLink}</p>
                <p>Falls Sie diese Anfrage nicht gestellt haben, ignorieren Sie diese E-Mail.</p>";

                await SendEmailAsync(email, subject, body);
            }
        }

        private async Task SendEmailAsync(string email, string subject, string body)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                //Roman
                //Credentials = new NetworkCredential("61df202cfe8e32", "e673b66b5c3352"),
                //Thomas
                Credentials = new NetworkCredential("61df202cfe8e32", "e673b66b5c3352"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@stempelapp.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new InvalidOperationException($"Fehler beim E-Mail-Versand: {ex.Message}");
            }
        }
    }
}
