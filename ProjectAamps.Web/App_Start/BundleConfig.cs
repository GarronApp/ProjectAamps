using System.Web;
using System.Web.Optimization;

namespace AAMPS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/autoNumeric/autoNumeric-1.9.25.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/d3.js",
                      "~/Scripts/c3.js",
                      "~/Scripts/jquery.mask.js",
                      "~/Scripts/app/exceptions.js",
                      "~/Scripts/app/resources.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css",
                      "~/Content/datepicker.css",
                      "~/Content/c3.css"));
        }
    }
}
