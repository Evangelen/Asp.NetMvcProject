using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using Company.DomainModels;

[assembly: OwinStartup(typeof(LeaveManagementSystem.Startup1))]

namespace LeaveManagementSystem
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new CompanyDbContext()));
            var appDbContext = new CompanyDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            //create Employee role
            if (!roleManager.RoleExists("GeneralEmployee"))
            {
                var role = new IdentityRole();
                role.Name = "GeneralEmployee";
                roleManager.Create(role);
            }

            //create ProjectManager role
            if (!roleManager.RoleExists("ProjectManager"))
            {
                var role = new IdentityRole();
                role.Name = "ProjectManager";
                roleManager.Create(role);
            }

            //create HRDept role
            if (!roleManager.RoleExists("HRDept"))
            {
                var role = new IdentityRole();
                role.Name = "HRDept";
                roleManager.Create(role);
            }

            //create HRDept role
            if (!roleManager.RoleExists("HRWithSpecialPermission"))
            {
                var role = new IdentityRole();
                role.Name = "HRWithSpecialPermission";
                roleManager.Create(role);
            }

            //create ProjectManager user
            if (userManager.FindByName("Anna")==null)
            {
                var user = new Employees();
                user.EmpName = "Anna";
                user.EmpPosition = "Senior Engineer";
                user.UserName = "anna@mail.com";
                user.EmpEmailId = "anna@mail.com";
                user.EmpRole = "ProjectManager";
                user.DeptId=32;
                string userPassword = "Anna123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "ProjectManager");
                }
            }


            //create HRDept user
            if (userManager.FindByName("Amit") == null)
            {
                var user = new Employees();
                user.EmpName = "Amit";
                user.EmpPosition = "Public Relations";
                user.UserName = "amit@mail.com";
                user.EmpEmailId = "amit@mail.com";
                user.EmpRole = "HRDept";
                user.DeptId=37;
                string userPassword = "Amit123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "HRDept");
                }
            }


            //create GeneralEmployee user
            if (userManager.FindByName("Annie") == null)
            {
                var user = new Employees();
                user.EmpName = "Annie";
                user.EmpPosition = "Intern";
                user.UserName = "annie@mail.com";
                user.EmpEmailId = "annie@mail.com";
                user.EmpRole = "GeneralEmployee";
                user.DeptId=34;
                string userPassword = "Annie123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "GeneralEmployee");
                }
            }
        }
    }
}
