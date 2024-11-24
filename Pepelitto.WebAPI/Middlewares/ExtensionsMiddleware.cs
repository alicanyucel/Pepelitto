using Microsoft.AspNetCore.Identity;
using Pepelitto.Domain.Entities;

namespace Pepelitto.WebAPI.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateFirstUser(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!userManager.Users.Any(p => p.UserName == "admin"))
                {
                    AppUser user = new()
                    {
                        UserName = "admin", // token kullanıcı adı:admin şifre:1
                        Email = "admin@admin.com",
                        FirstName = "Pepelitto",
                        LastName = "Pepelitto",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, "1").Wait();
                }
            }
        }
    }
}
