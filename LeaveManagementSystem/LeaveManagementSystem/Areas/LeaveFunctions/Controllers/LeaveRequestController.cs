using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.ViewModels;
using LeaveManagementSystem.Filter;
using Company.ServiceContracts;
using Company.ServiceLayer;
using System.Web.Helpers;


namespace LeaveManagementSystem.Areas.LeaveFunctions.Controllers
{
    
    public class LeaveRequestController : Controller
    {
        ILeaveRequestsServices RequestsServices;
        ILeaveApplicationServices applicationServices;

        public LeaveRequestController(ILeaveRequestsServices services, ILeaveApplicationServices applicationService)
        {
            this.RequestsServices = services;
            this.applicationServices = applicationService;
        }

        // GET: LeaveFunctions/LeaveRequest
        public ActionResult ViewAll()
        {
            List<Leave> leaveList = new List<Leave>();

            if (User.IsInRole("HRDept")||User.IsInRole("HRWithSpecialPermission"))
            {
                leaveList = RequestsServices.GetAllLeaves();
            }
            else if (User.IsInRole("ProjectManager"))
            {
                leaveList = RequestsServices.GetLeavesWithEmployees();
            }
            return View(leaveList);
        }

        [CustomAuthorization]
        public ActionResult ViewDetails(long id)
        {
            ViewBag.Status = applicationServices.GetStatuses();
            Leave leaveDetails = RequestsServices.Viewdetails(id);
            return View(leaveDetails);
        }


        [HttpPost]
        [CustomAuthorization]
        public ActionResult UpdateLeaveStatus(long id, Leave leave)
        {
            RequestsServices.UpdateLeaveStatus(id, leave);
            return RedirectToAction("ViewAll", "LeaveRequest", "LeaveFunctions");
        }



    }
} 
