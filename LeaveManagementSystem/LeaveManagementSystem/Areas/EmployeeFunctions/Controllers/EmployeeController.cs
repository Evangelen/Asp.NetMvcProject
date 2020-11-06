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


namespace LeaveManagementSystem.Areas.EmployeeFunctions.Controllers
{
    public class EmployeeController : Controller
    {
        IAccountServices accountServices;
        IProfileServices profileServices;

        public EmployeeController(IAccountServices services, IProfileServices profile)
        {
            this.accountServices = services;
            this.profileServices = profile;
        }

        // GET: EmployeeFunctions/Employee
        public ActionResult EmployeeIndex(string SearchByRole, string SearchByName)
        {
            var EmployeeList = accountServices.GetAllEmployees();
            if (SearchByRole != null)
            {
                var empList = profileServices.SearchByRole(SearchByRole);
                return View(empList);
            }
            if (SearchByName != null)
            {
                var emplist = profileServices.SearchByName(SearchByName);
                return View(emplist);
            }
            return View(EmployeeList);
        }

        public ActionResult EditEmployee(string id)
        {
            var employee = accountServices.GetEmployeeById(id);
            ViewBag.Departments = accountServices.GetDepartments();
            return View(employee);
        }


        [HttpPost]
        public ActionResult EditEmployee(string id, Employees emp)
        {
            if (ModelState.IsValid)
            {
                var employee = accountServices.GetEmployeeById(id);
                accountServices.EditEmployee(employee, emp);
                TempData["success"] = "The employee has been successfully edited";
                return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
            }
            else
            {
                TempData["failure"] = "The employee could not be edited";
                return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
            }
        }


        [Authorize(Roles = "HRDept")]
        public ActionResult Register()
        {
            ViewBag.Departments = accountServices.GetDepartments();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "HRDept")]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Departments = accountServices.GetDepartments();
                var user = accountServices.Register(rvm);

                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    user.ImageUrl = base64String;
                    accountServices.UpdateUser(user);
                }

                if (user != null)
                {
                    TempData["success"] = "The employee has been successfully added";
                    return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
                }

                else
                {
                    TempData["failure"] = "The employee could not be added";
                    return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
                }
            }
            else
            {
                TempData["failure"] = "The employee could not be added";
                return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
            }

        }

        [Authorize(Roles = "HRDept")]
        public ActionResult DeleteEmployee(string id)
        {
            var employee = accountServices.GetEmployeeById(id);
            accountServices.DeleteEmployee(employee);
            return RedirectToAction("EmployeeIndex", "Employee", new { area = "EmployeeFunctions" });
        }
    }
}