using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ranta.LogMagic.Display
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LogPagingRoute",
                url: "log/{page}",
                constraints: new { page = @"\d{1,5}" },
                defaults: new { controller = "log", action = "page", page = 1 }
            );

            routes.MapRoute(
                name: "LogDetailRoute",
                url: "log/{name}",
                constraints: new { name = @"[a-zA-Z0-9\-]+" },
                defaults: new { controller = "log", action = "detail", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}