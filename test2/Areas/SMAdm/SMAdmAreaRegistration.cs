using System.Web.Mvc;

namespace test2.Areas.SMAdm
{
    public class SMAdmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SMAdm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SMAdm_default",
                "SMAdm/{controller}/{action}/{id}",
                new { action = "Index",controller="Home", id = UrlParameter.Optional },
                new string[] { "test2.Areas.SMAdm.Controllers" }
            );
        }
    }
}