namespace Company.DomainModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Company.DomainModels.CompanyDbContext>
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
            context.Departments.AddOrUpdate(p=>p.DeptName, new Department { DeptName = "BusinessDevelopment" },
                                                                          new Department { DeptName = "Sales & Marketing" },
                                                                          new Department { DeptName = "Development" },
                                                                          new Department { DeptName = "Architecture" },
                                                                          new Department { DeptName = "HR" },
                                                                          new Department { DeptName = "Operations" });
            context.LeaveStatuses.AddOrUpdate(p=>p.StatusName, new LeaveStatus { StatusName = "Pending",StatusDescription="Pending Approval" },
                                                                 new LeaveStatus { StatusName = "Approve", StatusDescription = "Leave has been approved" },
                                                                 new LeaveStatus { StatusName = "Reject", StatusDescription = "Leave has been approved" });
            context.TypeOfLeaves.AddOrUpdate(p=>p.LeaveTypeName, new TypeOfLeave { LeaveTypeName = "CasualLeave", LeavesPerYear = 10 },
                                                                new TypeOfLeave { LeaveTypeName = "MedicalLeave", LeavesPerYear = 20 },
                                                                new TypeOfLeave { LeaveTypeName = "MaternityLeave", LeavesPerYear = 120 },
                                                                new TypeOfLeave { LeaveTypeName = "HalfPayLeave", LeavesPerYear = 10 });
        }
    }
}
