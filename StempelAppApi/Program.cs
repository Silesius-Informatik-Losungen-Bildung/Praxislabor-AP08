using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StempelAppApi.Data;
using StempelAppApi.Services;

namespace StempelAppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var sqlSilesius = Environment.GetEnvironmentVariable("SqlSilesius", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08User = Environment.GetEnvironmentVariable("SqlSilesiusAp08User", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08Pwd = Environment.GetEnvironmentVariable("SqlSilesiusAp08Pwd", EnvironmentVariableTarget.User);


            var connstr = builder.Configuration.GetConnectionString("default")
                .Replace("@SqlSilesius", sqlSilesius)
                .Replace("@Ap08User", sqlSilesiusAp08User)
                .Replace("@Ap08Pwd", sqlSilesiusAp08Pwd);
            builder.Services.AddDbContext<StempelAppDbContext>(options =>
                options.UseSqlServer(connstr)
                );

            // Identity mit Email-Bestätigung
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Email-Bestätigung erforderlich
                options.SignIn.RequireConfirmedEmail = true;

                // Passwort-Richtlinien
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false; // <- Fehlte
                options.Password.RequireDigit = false; // <- Fehlte

                // Token-Einstellungen
                //options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                //options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            })
            .AddEntityFrameworkStores<StempelAppDbContext>()
             .AddDefaultTokenProviders();

            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(24));

            // Email Service
            builder.Services.AddScoped<IEmailService, EmailService>();

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}
