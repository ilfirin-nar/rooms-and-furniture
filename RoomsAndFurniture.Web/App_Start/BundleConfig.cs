using System.Web.Optimization;

namespace RoomsAndFurniture.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                "~/Content/Styles/main.css",
                "~/Content/Styles/tables.css",
                "~/Content/Styles/rooms.css",
                "~/Content/Styles/history.css"));
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                "~/Scripts/rooms.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include(
                "~/Scripts/Libs/jquery-ui-1.11.4/external/jquery/jquery.js",
                "~/Scripts/Libs/jquery-ui-1.11.4/jquery-ui.min.js"));
            bundles.Add(new StyleBundle("~/Content/Styles/Jquery").Include(
                "~/Scripts/Libs/jquery-ui-1.11.4/jquery-ui.min.css",
                "~/Scripts/Libs/jquery-ui-1.11.4/jquery-ui.structure.min.css",
                "~/Scripts/Libs/jquery-ui-1.11.4/jquery-ui.theme.min.css"));
        }
    }
}
