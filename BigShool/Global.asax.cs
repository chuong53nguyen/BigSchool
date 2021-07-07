using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using BigShool.Models;
using System.Web.Routing;
using System.Data.Entity;
using System.Web.Optimization;
using System.Collections.Generic;

namespace BigShool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
