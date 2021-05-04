using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using digitalEnsi.Services;
using Microsoft.Extensions.DependencyInjection;
using digitalEnsi.Models;

namespace digitalEnsi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await Initialize(host.Services.CreateScope().ServiceProvider);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task Initialize(IServiceProvider serviceProvider)
        {   
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleNames = new List<string>(){"Admin","Enseignant","Etudiant"};
            IdentityResult result;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            //a changer ApplicationUser au model du l'admin
            var userManager = serviceProvider.GetRequiredService<UserManager<Administrateur>>();
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var admin = await userManager.FindByEmailAsync(config["AdminCredentials:Email"]);
            
            if (admin == null)
            {
                admin = new Administrateur()
                {
                    UserName = config["AdminCredentials:Email"],
                    Email = config["AdminCredentials:Email"],
                    EmailConfirmed = true
                };
                result = await userManager.CreateAsync(admin, config["AdminCredentials:Password"]);
                if (result.Succeeded)
                {
                    result = await userManager.AddToRoleAsync(admin, "Admin");
                    if (!result.Succeeded)
                    {
                        // todo: process errors
                    }
                }
            }



            
        }
    }
}
