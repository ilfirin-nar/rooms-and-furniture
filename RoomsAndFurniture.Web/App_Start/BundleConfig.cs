using System.Web.Optimization;

namespace RoomsAndFurniture.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Styles").Include("~/Content/Styles/*.css"));
            bundles.Add(new ScriptBundle("~/Scripts/Common").Include(
                "~/Scripts/modules.js",
                "~/Scripts/start.js",
                "~/Scripts/urls.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Home").Include(
                "~/Scripts/templates/roomsTableTemplates.js",
                "~/Scripts/pages/home.js",
                "~/Scripts/dialogs/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/History").Include("~/Scripts/pages/history.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include(
                "~/Scripts/libs/jquery-ui-1.11.4/external/jquery/jquery.js",
                "~/Scripts/libs/jquery-ui-1.11.4/jquery-ui.min.js"));
            bundles.Add(new StyleBundle("~/Content/Styles/Jquery").Include(
                "~/Scripts/libs/jquery-ui-1.11.4/jquery-ui.min.css",
                "~/Scripts/libs/jquery-ui-1.11.4/jquery-ui.structure.min.css",
                "~/Scripts/libs/jquery-ui-1.11.4/jquery-ui.theme.min.css"));
        }
    }
}
