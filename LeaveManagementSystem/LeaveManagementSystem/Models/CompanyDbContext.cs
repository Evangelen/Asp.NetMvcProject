using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LeaveManagementSystem.Migrations;

namespace LeaveManagementSystem.Models
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext() : base("ProjectConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }
        public DbSet<Employees> Employees { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}