using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StempelApp.Data;

namespace StempelApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // *** DATA PROTECTION HINZUFÜGEN ***
            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "keys")))
                .SetApplicationName("StempelApp")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

            var sqlSilesius = Environment.GetEnvironmentVariable("SqlSilesius", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08User = Environment.GetEnvironmentVariable("SqlSilesiusAp08User", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08Pwd = Environment.GetEnvironmentVariable("SqlSilesiusAp08Pwd", EnvironmentVariableTarget.User);

            var connstr = builder.Configuration.GetConnectionString("default")
                .Replace("@SqlSilesius", sqlSilesius)
                .Replace("@Ap08User", sqlSilesiusAp08User)
                .Replace("@Ap08Pwd", sqlSilesiusAp08Pwd);

            builder.Services.AddDbContext<StempelAppDbContext>(options =>
                options.UseSqlServer(connstr));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<StempelAppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(); // Identity.DefaultScheme
            builder.Services.AddAuthorization();

            // Token-Config vereinfachen (dupliziert sich mit AddIdentity)
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(24));

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient("AccountApi", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5209/");
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Dashboard}/{id?}");

            app.Run();
        }
    }
}
