using AutoTrade.Constants;
using Data.AutoTrade.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Services
{
    public static class SeederDB
    {
        public static void SeedData(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                var result = managerRole.CreateAsync(new AppRole
                {
                    Name = Roles.Admin
                }).Result;

                result = managerRole.CreateAsync(new AppRole
                {
                    Name = Roles.User
                }).Result;

                string email = "admin@gmail.com";
                var user = new AppUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+11(111)111-11-11"
                };
                result = manager.CreateAsync(user, "Qwerty1-").Result;
                result = manager.AddToRoleAsync(user, Roles.Admin).Result;
            }
        }
    }
}
