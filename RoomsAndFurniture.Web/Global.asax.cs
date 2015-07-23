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
            ServiceInstaller.Install();
        }

        void Application_Error(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
