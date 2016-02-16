using System.Web;
using System.Web.Optimization;

namespace WebAuthForm
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap/bootstrap.css",
                      "~/Content/css/bootstrap/bootstrap-theme.css",
                      "~/Content/css/bootstrap/bootstrap.css.map",
                      "~/Content/css/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                    "~/Scripts/jquery/jquery-{version}.js",
                    "~/Scripts/json2.js",
                    "~/Scripts/knockout-3.4.0.js",
                    "~/Scripts/jquery-ui-{version}.js"));       

        }
    }
}
