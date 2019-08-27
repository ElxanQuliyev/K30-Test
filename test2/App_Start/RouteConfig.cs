using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace test2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                    name: "Blogs",
                    url: "News/{id}/{*title}",
                    defaults: new { controller = "Home", action = "BlogDetail" },
                   namespaces: new string[] { "test2.Controllers" }
                    );
            routes.MapRoute(
                   name: "AreasDetail",
                   url: "areas-of-activity/{id}/{*title}",
                   defaults: new { controller = "Home", action = "AreasDetail" },
                   namespaces: new string[] { "test2.Controllers" }


               );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "test2.Controllers" }

            );
        }
    }
}
