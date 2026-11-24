using Microsoft.AspNetCore.Identity;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Extensions;

public static class CreateAdminExtension
{
    public static void CreateAdmin(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any(p => p.Email == "admin@gmail.com"))
            {
                AppUser user = new()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                };
                userManager.CreateAsync(user, "Password123*").Wait();
            }
        }
    }
}
