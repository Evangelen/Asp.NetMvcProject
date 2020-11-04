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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http.ModelBinding;

namespace Company.RepositoryLayer
{
    public class ProfileRepository : IProfileRepository
    {
        CompanyDbContext appDbContext;

        public ProfileRepository()
        {
            this.appDbContext = new CompanyDbContext();
        }

        public string ChangePassword(Employees emp,ChangePassword model)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            string status = "";
            
            IdentityResult result= userManager.ChangePassword(emp.Id, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                userManager.Update(emp);
                status = "Success";
                return status;
            }
            else
            {
                status = "Failed";
                return status;
            }
        }

        public void Edit(Employees currentEmployee, Employees newEmployee)
        {
            currentEmployee.EmpName = newEmployee.EmpName;
            currentEmployee.EmpPosition = newEmployee.EmpPosition;
            if (currentEmployee.EmpEdu.Count>0)
            {
                for (int i = 0; i < newEmployee.EmpEdu.Count(); i++)
                {
                    if (i<currentEmployee.EmpEdu.Count())
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

            currentEmployee.EmpEdu = newEmployee.EmpEdu;

            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            userManager.Update(currentEmployee);
        }

        public Employees GetEmployee()
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            Employees appUser = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return appUser;
        }

        public List<Employees> SearchByRole(string search)
        {
            var empList = appDbContext.Users.Where(m => m.EmpRole == search).ToList();
            return empList;
        }

        public List<Employees> SearchByName(string search)
        {
            var empList = appDbContext.Users.Where(m => m.EmpName.Contains(search)).ToList();
            return empList;
        }
    }
}
