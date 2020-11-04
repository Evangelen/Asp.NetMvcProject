using System.Web.Mvc;

namespace LeaveManagementSystem.Areas.ProfileFunctions
{
    public class ProfileFunctionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProfileFunctions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProfileFunctions_default",
                "ProfileFunctions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}