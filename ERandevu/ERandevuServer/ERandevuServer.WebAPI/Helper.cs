﻿using ERandevuServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ERandevuServer.WebAPI
{
    public static class Helper
    {
        public static async Task CreateUserAsync(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any())
                {
                    await userManager.CreateAsync(new()
                    {
                        FirstName = "Batuhan",
                        LastName = "Keskin",
                        Email = "batu@admin.com",
                        UserName = "admin"
                    }, "1");
                }
            }
        }
    }
}
