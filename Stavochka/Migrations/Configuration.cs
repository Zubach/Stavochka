using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Stavochka.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Stavochka.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<Stavochka.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Stavochka.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.Roles.Any())
            {
                IdentityRole roleAdmin = new IdentityRole()
                {
                    Name = "Admin",
                };
                IdentityRole roleUser = new IdentityRole()
                {
                    Name = "User",
                };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);
            }
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            if (!userManager.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                userManager.Create(user, "Qwerty-1");
                userManager.AddToRole(user.Id, "Admin");
            }
            }
    }
}
