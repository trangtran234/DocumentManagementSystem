using System.Web;
using System.Web.Optimization;

namespace DocumentManagementSystem.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                      "~/Scripts/lib/angular/angular.js",
                      "~/Scripts/lib/jQuery/dist/jquery.js",
                      "~/Scripts/lib/bootstrap/dist/js/bootstrap.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/Contents").Include(
                            "~/Content/models/*.js",
                            "~/Content/services/*.js",
                            "~/Content/directives/*.js",
                            "~/Content/controllers/*.js",
                            "~/Content/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Scripts/lib/bootstrap/dist/css/bootstrap.min.css",
                        "~/styles/*.css"));
        }
    }
}
