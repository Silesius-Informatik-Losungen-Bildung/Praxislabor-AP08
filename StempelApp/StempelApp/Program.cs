namespace StempelApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var sqlSilesius = Environment.GetEnvironmentVariable("SqlSilesius", EnvironmentVariableTarget.User);   // Instanzname mit Port
            var sqlSilesiusAp08User = Environment.GetEnvironmentVariable("SqlSilesiusAp08User", EnvironmentVariableTarget.User);  // User ID - wie bekanntgegeben
            var sqlSilesiusAp08Pwd = Environment.GetEnvironmentVariable("SqlSilesiusAp08Pwd", EnvironmentVariableTarget.User); // PWD, wie bekanntgegeben
            buider.Services.UseSqlServer($"Password={sqlSilesiusAp08Pwd};Persist Security Info=True;User ID={sqlSilesiusAp08User};Initial Catalog=StempelApp;Data Source={sqlSilesius};TrustServerCertificate=True;");


            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/Login";
                });

            builder.Services.AddAuthorization();

            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
