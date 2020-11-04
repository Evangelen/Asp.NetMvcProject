using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Company.DomainModels;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;



namespace LeaveManagementSystem.Filter
{
    public class CustomAuthorization : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((filterContext.HttpContext.User.IsInRole("ProjectManager") || filterContext.HttpContext.User.IsInRole("HRWithSpecialPermission"))==false)
            {
                filterContext.Result = new HttpUnauthorizedResult(); 
            }
        }
    }
}