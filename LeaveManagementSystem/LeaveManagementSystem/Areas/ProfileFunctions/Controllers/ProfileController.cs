using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.ServiceContracts;
using Company.ServiceLayer;
using Company.DomainModels;
using Company.ViewModels;
using LeaveManagementSystem.Filter;


namespace LeaveManagementSystem.Areas.ProfileFunctions.Controllers
{
    [MyAuthenticationFilter]
    public class ProfileController : Controller
    {
        IProfileServices profileServices;

        public ProfileController(IProfileServices services)
        {
            this.profileServices = services;
        }

        // GET: ProfileFunctions/Profile
        public ActionResult MyProfile()
        {
            Employees currentUser = profileServices.GetEmployee();
            return View(currentUser);
        }

        public ActionResult Edit()
        {
            Employees currentUser = profileServices.GetEmployee();
            return View(currentUser);
        }


        [HttpPost]
        public ActionResult Edit(Employees newEmp)
        {
            if (ModelState.IsValid)
            {
                Employees currentUser = profileServices.GetEmployee();
                profileServices.Edit(currentUser, newEmp);
                TempData["success"] = "The employee has been successfully edited";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                TempData["failure"] = "The profile could not be edited";
                return RedirectToAction("MyProfile", "Profile", new { area = "ProfileFunctions" });
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePassword change)
        {
            if (ModelState.IsValid)
            {
                Employees currentUser = profileServices.GetEmployee();
                string status = profileServices.ChangePassword(currentUser, change);

                if (status == "Success")
                {
                    TempData["success"] = "The password has been changed successfully";
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

                else
                {
                    TempData["failure"] = "The password is incorrect";
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
        }
    }
}