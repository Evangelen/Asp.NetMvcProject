using LeaveManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        CompanyDbContext Db = new CompanyDbContext();

        // GET: Home
        public ActionResult Index()
        { 
            List<Employees> employees = Db.Employees.ToList();
            return View(employees);
        }


        public ActionResult Edit(long id)
        {
            Employees emp = Db.Employees.Where(m=>m.EmpId==id).FirstOrDefault();
            ViewBag.count = emp.EmpEdu.Count();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employees Emp, List<Education> education)
        {
            if (ModelState.IsValid)
            {
                Employees existingEmp = Db.Employees.Where(m => m.EmpId == Emp.EmpId).FirstOrDefault();
                existingEmp.EmpName = Emp.EmpName;
                existingEmp.EmpEmailId = Emp.EmpEmailId;

                for (int i = 0; i < existingEmp.EmpEdu.Count(); i++)
                {
                    existingEmp.EmpEdu[i].EduLevel = Emp.EmpEdu[i].EduLevel;
                    existingEmp.EmpEdu[i].EduYOP = Emp.EmpEdu[i].EduYOP;
                }
                for (int i = existingEmp.EmpEdu.Count; i < Emp.EmpEdu.Count(); i++)
                {
                    existingEmp.EmpEdu.Add(Emp.EmpEdu[i]);
                    existingEmp.EmpEdu[i].EduLevel = Emp.EmpEdu[i].EduLevel;
                    existingEmp.EmpEdu[i].EduYOP = Emp.EmpEdu[i].EduYOP;
                }
                existingEmp.EmpEdu = Emp.EmpEdu;
                Db.SaveChanges();
                TempData["success"] = "The employee has been successfully added";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees Emp, List<Education> education)
        {
            if (ModelState.IsValid)
            {

                Db.Employees.Add(Emp);
                Db.SaveChanges();
                TempData["success"] = "The employee has been successfully added";
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}