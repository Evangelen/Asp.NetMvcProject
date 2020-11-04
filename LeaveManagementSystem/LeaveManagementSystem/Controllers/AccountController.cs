using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.UI.WebControls.WebParts;
using Company.DomainModels;
using Company.ViewModels;
using Company.ServiceContracts;
using Company.ServiceLayer;


namespace LeaveManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        IAccountServices accountServices;

        public AccountController(IAccountServices services)
        {
            this.accountServices = services;
        }

        // GET: Account

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var user = accountServices.GetUserForLogin(lvm);
            if (user != null)
            {
                Session["UserId"] = user.Id;
                Session["UserName"] = user.UserName;

                HttpCookie UserId = new HttpCookie("UserId", user.Id);
                Response.Cookies.Add(UserId);
                UserId.Expires = DateTime.Now.AddMinutes(30);
                HttpCookie username = new HttpCookie("UserName", user.UserName);
                Response.Cookies.Add(username);
                username.Expires = DateTime.Now.AddMinutes(30);
                
                return RedirectToAction("Index", "Home");                
            }

            else
            {
                ModelState.AddModelError("myerror", "Invalid username or password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetPhoto()
        {
            var Img = accountServices.GetImage();
            if (Img!=null)
            {
                return File(Img, "image/jpeg");
            }
            else
            {
                string fileName = "~/ProfPic.jpg";
                return File(fileName, "image/jpeg");
            }
            
        }
    }
}