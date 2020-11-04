using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Company.DomainModels;

namespace Company.DataLayer
{
    public class CompanyDbContext:IdentityDbContext<Employees>
    {
        public CompanyDbContext():base("ProjectConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>);
        }

        public DbSet<Education> educations { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
