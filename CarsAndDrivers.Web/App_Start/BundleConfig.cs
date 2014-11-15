using System.Web;
using System.Web.Optimization;

namespace CarsAndDrivers
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/Kendo/kendo.all.min.js",
                        "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Kendo/jquery.min.js"));
                        //"~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryeasing").Include(
                        "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/site-landingpage.js"));

            bundles.Add(new ScriptBundle("~/bundles/sitemain").Include(
                       "~/Scripts/MainSite.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/cssmain").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/MainSite.css"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/SiteLandingPage.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                      "~/Content/Kendo/kendo.common.min.css",
                      "~/Content/Kendo/kendo.common-bootstrap.min.css",
                      "~/Content/Kendo/kendo.silver.min.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
