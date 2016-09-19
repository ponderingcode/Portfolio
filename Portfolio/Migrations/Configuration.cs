namespace Portfolio.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Portfolio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == UserRole.ADMINISTRATOR))
            {
                roleManager.Create(new IdentityRole { Name = UserRole.ADMINISTRATOR });
            }

            if (!context.Roles.Any(r => r.Name == UserRole.MODERATOR))
            {
                roleManager.Create(new IdentityRole { Name = UserRole.MODERATOR });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "ryan@ponderingcode.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ryan@ponderingcode.com",
                    Email = "ryan@ponderingcode.com",
                    FirstName = "Ryan",
                    LastName = "Fleming",
                    DisplayName = "Ryan Fleming",
                }, "CoderFoundry");
            }

            var administratorUserID = userManager.FindByEmail("ryan@ponderingcode.com").Id;
            userManager.AddToRole(administratorUserID, UserRole.ADMINISTRATOR);

            if (!context.Users.Any(u => u.Email == "jtwichell@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jtwichell@coderfoundry.com",
                    Email = "jtwichell@coderfoundry.com",
                    FirstName = "Jason",
                    LastName = "Twichell",
                    DisplayName = "J-Twich",
                }, "Abc&123!");
            }

            var moderatorUserId = userManager.FindByEmail("jtwichell@coderfoundry.com").Id;
            userManager.AddToRole(moderatorUserId, UserRole.MODERATOR);
        }
    }
}