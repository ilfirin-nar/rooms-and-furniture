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
        }
    }
}
