using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Premium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = CreateHostBuilder(args).Build())
            {
                try
                {

                    using (var scope = host.Services.CreateScope())
                    {
                        var ctx = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                        bool v = ctx.Database.EnsureCreated();

                        var adminRole = new IdentityRole("Admin");
                        if (!ctx.Roles.Any())
                        {
                            //create a role
                            roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                        }
                        if (!ctx.Users.Any(u => u.UserName == "admin"))
                        {
                            //create an admin
                            var adminUser = new IdentityUser
                            {
                                UserName = "admin",
                                Email = "admin@test.com"
                            };
                            var result = userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                            //add role to user
                            userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
