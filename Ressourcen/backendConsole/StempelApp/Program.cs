using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StempelAppCore.Data;
using StempelAppCore.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Services konfigurieren
builder.Services.AddDbContext<StempelAppContext>(options =>
    options.UseInMemoryDatabase("StempelApp"));

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddHttpClient("StempelApp", client =>
{
    client.BaseAddress = new Uri("http://localhost:5209");
});

var app = builder.Build();

// 2. Middleware Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Wichtig für den Login-Status
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

// 3. Datenbank Seeding (InMemory Daten generieren)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StempelAppContext>();

    // --- TEIL 1: System-User (Personal & Admin) ---
    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new User
            {
                FirstName = "Admin",
                LastName = "System",
                Username = "admin",
                UserTypeId = 15, // 15 = Admin-Berechtigung
                ContactInfo = new ContactInfo { Email = "admin@test.de", PhoneNumber = "0123456789" },
                PasswordHash = "admin123",
                UserGuid = Guid.NewGuid()
            },
            new User
            {
                FirstName = "Max",
                LastName = "Mustermann",
                Username = "max",
                UserTypeId = 5, // 5 = Reinigungspersonal
                ContactInfo = new ContactInfo { Email = "max@test.de", PhoneNumber = "987654321" },
                PasswordHash = "max123",
                UserGuid = Guid.NewGuid()
            }
        );
        context.SaveChanges();
    }

    // --- TEIL 2: Immobilienbesitzer (Customer) & Projekte ---
    if (!context.Customers.Any())
    {
        context.Customers.AddRange(
            new Customer
            {
                UserType = UserType.BuildingOwner,
                User = new User
                {
                    FirstName = "Monika",
                    LastName = "Miethai",
                    Username = "monika",
                    UserTypeId = 10, // 10 = BuildingOwner
                    ContactInfo = new ContactInfo { Email = "monika@wohnen.de", PhoneNumber="0123456789" },
                    PasswordHash = "monika123",
                    UserGuid = Guid.NewGuid()
                },
                Projects = new List<Project>
                {
                    new Project
                    {
                        CustomerName = "Wohnen & Co Anlage",
                        Address = new Address { StreetHouseNr = "Hauptstraße 1", City = "Wien" },
                        Activities = new List<string> { "Fensterreinigung", "Stiegenhaus" }
                    }
                }
            },
            new Customer
            {
                UserType = UserType.BuildingOwner,
                User = new User
                {
                    FirstName = "Claus",
                    LastName = "Stein",
                    Username = "claus",
                    UserTypeId = 10,
                    ContactInfo = new ContactInfo { Email = "claus@stein.de", PhoneNumber="9876543210" },
                    PasswordHash = "claus123",
                    UserGuid = Guid.NewGuid()
                },
                Projects = new List<Project>
                {
                    new Project
                    {
                        CustomerName = "Stein-Invest Büro",
                        Address = new Address { StreetHouseNr = "Schlossplatz 5", City = "Berlin" },
                        Activities = new List<string> { "Grundreinigung", "Büroservice" }
                    }
                }
            }
        );
        context.SaveChanges();
    }
}

app.Run();