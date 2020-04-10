using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Web.Configuration;
using Covid19.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Covid19.Web.Context
{
    public class UserContext : IdentityDbContext<WebUser>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public static void SeedUserAdministrator(UserManager<WebUser> userManager)
        {


            if (userManager.FindByEmailAsync("helder@chebre.net").Result == null)
            {
                var user = new WebUser
                {
                    FirstName = "Helder",
                    LastName = "Chebre",
                    UserName = "helder@chebre.net",
                    Email = "helder@chebre.net",
                };


                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, "Administrator").Result;
                }


            }
        }
    }
}
