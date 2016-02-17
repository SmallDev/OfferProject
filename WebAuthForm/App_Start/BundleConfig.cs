using System.Web;
using System.Web.Optimization;

namespace WebAuthForm
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap/bootstrap.css",
                      "~/Content/css/bootstrap/bootstrap-theme.css",
                      "~/Content/css/bootstrap/bootstrap.css.map",
                      "~/Content/css/kendo/kendo.bootstrap.min.css",
                      "~/Content/css/kendo/kendo.bootstrap.min.css.map",
                      "~/Content/css/kendo/kendo.common-bootstrap.min.css",
                      "~/Content/css/kendo/kendo.common-bootstrap.min.css.map",
                      "~/Content/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                    "~/Scripts/jquery/jquery.min.js",
                    "~/Scripts/jquery/jquery.min.js.map",
                    "~/Scripts/json2.js",
                    "~/Scripts/knockout-3.4.0.js",
                    "~/Scripts/kendo/kendo.all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/app/offersListViewModel.js",
                    "~/Scripts/app/editOfferViewModel.js"));

        }
    }
}
