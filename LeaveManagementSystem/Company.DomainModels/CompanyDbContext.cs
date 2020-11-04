using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Company.DomainModels;
using Company.DomainModels.Migrations;

namespace Company.DomainModels
{
    public class CompanyDbContext : IdentityDbContext<Employees>
    {
        public CompanyDbContext() : base("ProjectConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Leave> Leaves { get; set; }
        
        public DbSet<TypeOfLeave> TypeOfLeaves { get; set; }

        public DbSet<LeaveStatus> LeaveStatuses { get; set; }
        
    }
}
