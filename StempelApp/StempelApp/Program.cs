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

            var sqlSilesius = Environment.GetEnvironmentVariable("SqlSilesius", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08User = Environment.GetEnvironmentVariable("SqlSilesiusAp08User", EnvironmentVariableTarget.User);
            var sqlSilesiusAp08Pwd = Environment.GetEnvironmentVariable("SqlSilesiusAp08Pwd", EnvironmentVariableTarget.User);

            builder.Services.AddDbContext<StempelAppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                .Replace("@SqlSilesius", sqlSilesius)
                .Replace("@sqlSilesiusAp08User", sqlSilesiusAp08User)
                .Replace("@sqlSilesiusAp08Pwd", sqlSilesiusAp08Pwd)
                ));

            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/Login";
                });
            builder.Services.AddAuthorization();


            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<IPasswordHasher<Benutzer>, PasswordHasher<Benutzer>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
