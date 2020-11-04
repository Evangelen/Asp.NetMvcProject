namespace LeaveManagementSystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Company.DomainModels;


    public class Configuration : DbMigrationsConfiguration<Company.DomainModels.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Company.DomainModels.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            
            var userStore = new ApplicationUserStore(context);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }
    }
}
