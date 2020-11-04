using System.Web.Mvc;

namespace LeaveManagementSystem.Areas.EmployeeFunctions
{
    public class EmployeeFunctionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmployeeFunctions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EmployeeFunctions_default",
                "EmployeeFunctions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}