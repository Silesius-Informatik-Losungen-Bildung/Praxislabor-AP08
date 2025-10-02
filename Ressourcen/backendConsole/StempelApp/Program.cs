using Microsoft.EntityFrameworkCore;
using StempelAppCore.Data;
using StempelAppCore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StempelAppContext>(options =>
    options.UseInMemoryDatabase("StempelApp"));
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();        
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StempelAppContext>();

    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new User {FirstName="admin", LastName="min", Username = "admin", ContactInfo = new ContactInfo { Email = "admin@test.de", PhoneNumber="0123456789" }, PasswordHash = "admin123" },
            new User {FirstName="Max", LastName="Mustermann", Username = "max", ContactInfo = new ContactInfo { Email = "max@test.de", PhoneNumber="987654321" }, PasswordHash = "max123" }
        );
        context.SaveChanges();
    }

    if (!context.Projects.Any())
    {
        var address = new Address
        {
            StreetHouseNr = "Musterstrasse 1",
            City = "Musterstadt",
            Country = new Country { CountryCode = "DE", CountryName = "Deutschland" }
        };

        var project = new Project
        {
            CustomerName = "Musterprojekt",
            Address = address,
            StartTime = new DateTime(2023, 10, 10, 06,00,00),
            CleaningPersonnel = new List<User> { context.Users.First(u => u.Username == "admin") },
            Activities = new List<string> { "Büroreinigung", "Fenster putzen" }
        };
        context.Projects.Add(project);
        context.SaveChanges();
    }
}


app.Run();