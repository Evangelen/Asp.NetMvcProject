using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using LeaveManagementSystem.Filter;


namespace LeaveManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home

        [MyAuthenticationFilter]
        public ActionResult Index()
        { 
            return View();
        }

    }
}