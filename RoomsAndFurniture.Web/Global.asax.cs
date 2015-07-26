using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace RoomsAndFurniture.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = ServiceInstaller.Install();
            container.GetInstance<IDatabaseInitializer>().Initialize();
        }

        void Application_Error(object sender, EventArgs e) {}
    }
}
