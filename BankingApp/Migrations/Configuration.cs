namespace BankingApp.Migrations
{
    using BankingApp.Models;
    using BankingApp.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankingApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BankingApp.Models.ApplicationDbContext";
        }

        protected override void Seed(BankingApp.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "admin.bankapp.com"))
            {
                var user = new ApplicationUser { UserName = "admin@bankapp.com", Email = "admin@bankapp.com" };
                userManager.Create(user, "BankBoss");

                var admin = new CheckingAcctService(context);
                admin.NewCheckingAcct("Admin", "User", 1000, user.Id);


                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
