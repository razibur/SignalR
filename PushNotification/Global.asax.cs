using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PushNotification
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string conStr = ConfigurationManager.ConnectionStrings["sqlConString"].ConnectionString;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SqlDependency.Start(conStr);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            NotificaitonComponents NC = new NotificaitonComponents();
            var currentTime = DateTime.Now;

            NC.RegisterNotification(currentTime);
        }

        protected void Application_End()
        {
            SqlDependency.Stop(conStr);
        }
    }
}
