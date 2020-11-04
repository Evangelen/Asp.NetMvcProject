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
    public class LeaveRequestsRepository:ILeaveRequestsRepository
    {
        CompanyDbContext appDbContext;

        public LeaveRequestsRepository()
        {
            this.appDbContext = new CompanyDbContext();
        }

        public List<Leave> GetAllLeaves()
        {
            var leaveList = appDbContext.Leaves.ToList();
            return leaveList;
        }

        public List<Leave> GetLeavesWithEmployees()
        {
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            userManager.UserValidator = new UserValidator<Employees>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            Employees appUser = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var leaveList = appDbContext.Leaves.Where(m => m.Employees.DeptId == appUser.DeptId).ToList();
            return leaveList;
        }

        public void UpdateLeaveStatus(long id,Leave newLeave)
        {
            Leave leave = appDbContext.Leaves.Where(m => m.LeaveId == id).FirstOrDefault();
            leave.StatusId = newLeave.StatusId;
            
            appDbContext.SaveChanges();
        }

        public Leave Viewdetails(long id)
        {
            Leave leaveDetails = appDbContext.Leaves.Where(m => m.LeaveId == id).FirstOrDefault();
            return leaveDetails;
        }
    }
}
