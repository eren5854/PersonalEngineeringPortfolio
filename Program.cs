using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Extensions;
using PersonalEngineeringPortfolio.Models;
using PersonalEngineeringPortfolio.Options;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// .env dosyasını oku, ortam değişkenlerini configuration'a ekle
Env.Load();
builder.Configuration.AddEnvironmentVariables();

// ---------- Veritabanı (PostgreSQL) ----------
var connectionString = builder.Configuration["DEFAULT_CONNECTION"]
    ?? throw new InvalidOperationException("DEFAULT_CONNECTION bulunamadı. .env dosyasını kontrol et.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// ---------- Identity ----------
builder.Services
    .AddIdentity<AppUser, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.SignIn.RequireConfirmedEmail = false; // e-posta onay akışı yok
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// ---------- JWT (HttpOnly cookie'den okunur) ----------
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddJwtCookieAuthentication();   // Extensions/AuthenticationExtensions.cs

// ---------- Service ve Repository kayıtları ----------
// IAuthService -> AuthService, IJwtProvider -> JwtProvider gibi eşleşenleri otomatik ekler.
builder.Services.Scan(scan => scan
    .FromAssemblies(typeof(Program).Assembly)
    .AddClasses(classes => classes.InNamespaces(
        "PersonalEngineeringPortfolio.Services",
        "PersonalEngineeringPortfolio.Repositories"), publicOnly: false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime());

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

CreateAdminExtension.CreateAdmin(app);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Bu blok kök adresi (/) otomatik olarak HomeController -> Index metoduna bağlar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Diğer controller'larda [Route] attribute kullanıyorsanız bunu da tutabilirsiniz:
app.MapControllers();

app.Run();