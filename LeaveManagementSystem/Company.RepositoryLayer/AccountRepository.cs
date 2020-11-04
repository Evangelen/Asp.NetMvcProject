using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.RepositoryContracts;
using Company.DomainModels;
using Company.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;


namespace Company.RepositoryLayer
{
    public class AccountRepository : IAccountRepository
    {
        CompanyDbContext appDbContext;

        public AccountRepository()
        {
            this.appDbContext = new CompanyDbContext();
        }

        public void DeleteEmployee(Employees emp)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            List<Education> eduList= appDbContext.Educations.Where(m => m.EmpList.Id == emp.Id).ToList();
            List<Leave> leaveList = appDbContext.Leaves.Where(m => m.Employees.Id == emp.Id).ToList();

            foreach (var item in leaveList)
            {
                appDbContext.Leaves.Remove(item);
                appDbContext.SaveChanges();
            }

            foreach (var item in eduList)
            {
                appDbContext.Educations.Remove(item);
                appDbContext.SaveChanges();
            }
            userManager.Delete(emp);
        }

        public void EditEmployee(Employees currentEmployee, Employees newEmployee)
        {
            currentEmployee.EmpName = newEmployee.EmpName;
            currentEmployee.EmpPosition = newEmployee.EmpPosition;

            if (currentEmployee.EmpEdu.Count > 0)
            {
                for (int i = 0; i < newEmployee.EmpEdu.Count(); i++)
                {
                    if (i < currentEmployee.EmpEdu.Count())
                    {
                        currentEmployee.EmpEdu[i].EduLevel = newEmployee.EmpEdu[i].EduLevel;
                        currentEmployee.EmpEdu[i].EduYOP = newEmployee.EmpEdu[i].EduYOP;
                    }
                    else
                    {
                        currentEmployee.EmpEdu.Add(newEmployee.EmpEdu[i]);
                        currentEmployee.EmpEdu[i].EduLevel = newEmployee.EmpEdu[i].EduLevel;
                        currentEmployee.EmpEdu[i].EduYOP = newEmployee.EmpEdu[i].EduYOP;
                    }
                }
            }

            else
            {
                for (int i = 0; i < newEmployee.EmpEdu.Count(); i++)
                {
                    currentEmployee.EmpEdu.Add(newEmployee.EmpEdu[i]);
                    currentEmployee.EmpEdu[i].EduLevel = newEmployee.EmpEdu[i].EduLevel;
                    currentEmployee.EmpEdu[i].EduYOP = newEmployee.EmpEdu[i].EduYOP;
                }
            }
            currentEmployee.Department = newEmployee.Department;

            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            userManager.Update(currentEmployee);
        }

        public List<Employees> GetAllEmployees()
        {
            var EmployeeList = appDbContext.Users.ToList();
            return EmployeeList;
        }

        public List<Department> GetDepartments()
        {
            var deptList = appDbContext.Departments.ToList();
            return deptList;
        }

        public Employees GetEmployeeById(string id)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var user = userManager.FindById(id);
            return user;
        }

        public byte[] GetImage()
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            Employees appUser = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            byte[] byteArray = null;

            if (appUser.ImageUrl!=null)
            {
                byteArray = System.Convert.FromBase64String(appUser.ImageUrl);
            }
            return byteArray;
        }

        public Employees GetUserForLogin(LoginViewModel lvm)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var user = userManager.Find(lvm.UserId, lvm.Password);
            if (user!=null)
            {
                var authManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties(), userIdentity);
            }
            return user;
        }

        public Employees Register(RegisterViewModel rvm)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var passwordHash = Crypto.HashPassword(rvm.Password);

            var user = new Employees()
            {
                EmpName = rvm.Name,
                EmpPosition = rvm.Designation,
                EmpEdu = rvm.EmpEdu,
                UserName = rvm.Email,
                EmpEmailId = rvm.Email,
                EmpRole = rvm.Role,
                DeptId=rvm.DepartmentID,
                IsSpecialPermission=rvm.IsSpecialPermission,
                PasswordHash = passwordHash
            };

            IdentityResult result= userManager.Create(user);

            if (result.Succeeded && rvm.Role == "GeneralEmployee")
            {
                userManager.AddToRole(user.Id, "GeneralEmployee");
            }

            else if (result.Succeeded && rvm.Role == "ProjectManager")
            {
                userManager.AddToRole(user.Id, "ProjectManager");
            }

            else if (result.Succeeded && rvm.Role == "HRDept")
            {
                if (rvm.IsSpecialPermission)
                {
                    userManager.AddToRole(user.Id, "HRWithSpecialPermission");
                }
                else
                {
                    userManager.AddToRole(user.Id, "HRDept");
                }
            }

            return user;
        }

        public void UpdateUser(Employees newEmp)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            userManager.Update(newEmp);
        }
    }
}
