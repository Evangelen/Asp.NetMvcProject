using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Company.ViewModels;
using Company.ServiceContracts;
using Company.ServiceLayer;


namespace LeaveManagementSystem.Areas.LeaveFunctions.Controllers
{
    public class LeaveApplicationController : Controller
    {
        ILeaveApplicationServices LeaveApplicationServices;

        public LeaveApplicationController(ILeaveApplicationServices services)
        {
            this.LeaveApplicationServices = services;
        }

        // GET: LeaveFunctions/LeaveApplication
        public ActionResult Index()
        {
            List<Leave> leaveList = LeaveApplicationServices.GetLeaveApplications();
            return View(leaveList);
        }

        [Authorize(Roles = "GeneralEmployee")]
        public ActionResult Create()
        {
            ViewBag.Types = LeaveApplicationServices.GetTypeOfLeaves();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Leave newLeave)
        {
            LeaveApplicationServices.CreateNewLeave(newLeave);
            return RedirectToAction("Index", "LeaveApplication");
        }


        public ActionResult Edit(long id)
        {
            ViewBag.Types = LeaveApplicationServices.GetTypeOfLeaves();
            Leave existingLeave = LeaveApplicationServices.GetLeaveWithId(id);
            return View(existingLeave);
        }


        [HttpPost]
        public ActionResult Edit(long id,Leave newLeave)
        {
            LeaveApplicationServices.EditLeave(id, newLeave);
            return RedirectToAction("Index", "LeaveApplication");
        }

        public ActionResult Delete(long id)
        {
            LeaveApplicationServices.DeleteLeave(id);
            return RedirectToAction("Index", "LeaveApplication");
        }
    }
}