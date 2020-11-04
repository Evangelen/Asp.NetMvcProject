using System.Web.Mvc;

namespace LeaveManagementSystem.Areas.LeaveFunctions
{
    public class LeaveFunctionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LeaveFunctions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LeaveFunctions_default",
                "LeaveFunctions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}