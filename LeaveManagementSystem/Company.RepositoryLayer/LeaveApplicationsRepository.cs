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

namespace Company.RepositoryLayer
{
    public class LeaveApplicationsRepository:ILeaveApplicationsRepository
    {
        CompanyDbContext appDbContext;

        public LeaveApplicationsRepository()
        {
            this.appDbContext = new CompanyDbContext();
        }

        public void CreateNewLeave(Leave newLeave)
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };


            Employees appUser = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //Employees appUser= System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //string id=userManager.getuserId
            //newLeave.Employees.Id = appUser.Id;

            var leave = new Leave()
            {
                StatusId = 23,
                Employees = appUser,
                //TypeOfLeave = newLeave.TypeOfLeave,
                Cause = newLeave.Cause,
                NoOfDays = newLeave.NoOfDays,
                StartDate = newLeave.StartDate,
                LeaveTypeId=newLeave.LeaveTypeId
            };


            appDbContext.Leaves.Add(leave);
            appDbContext.SaveChanges();
        }

        public void DeleteLeave(long id)
        {
            Leave existingLeave = appDbContext.Leaves.Where(m => m.LeaveId == id).FirstOrDefault();
            appDbContext.Leaves.Remove(existingLeave);
            appDbContext.SaveChanges();
        }

        public void EditLeave(long id,Leave newLeave)
        {
            Leave existingLeave = appDbContext.Leaves.Where(m => m.LeaveId == id).FirstOrDefault();
            existingLeave.StartDate = newLeave.StartDate;
            existingLeave.NoOfDays = newLeave.NoOfDays;
            existingLeave.LeaveTypeId = newLeave.LeaveTypeId;

            appDbContext.SaveChanges();
        }

        public List<Leave> GetLeaveApplications()
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            Employees appUser = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var userId = appUser.Id;
            List<Leave> leaveList = appDbContext.Leaves.Where(temp => temp.Employees.Id == userId).ToList();
            return leaveList;
        }

        public Leave GetLeaveWithId(long id)
        {
            Leave existingLeave = appDbContext.Leaves.Where(m => m.LeaveId == id).FirstOrDefault();
            return existingLeave;
        }

        public List<LeaveStatus> GetStatuses()
        {
            List<LeaveStatus> leaveStatuses = appDbContext.LeaveStatuses.ToList();
            return leaveStatuses;
        }

        public List<TypeOfLeave> GetTypeOfLeaves()
        {
            List<TypeOfLeave> typeOfLeaves = appDbContext.TypeOfLeaves.ToList();
            return typeOfLeaves;
        }
    }
}
