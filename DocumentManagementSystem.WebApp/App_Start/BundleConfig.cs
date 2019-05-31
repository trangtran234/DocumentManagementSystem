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
                      "~/Scripts/lib/angular/angular.min.js",
                      "~/Scripts/lib/angular-route/angular-route.min.js",
                      "~/Scripts/lib/angular-bootstrap/ui-bootstrap.min.js",
                      "~/Scripts/lib/angular-bootstrap/ui-bootstrap-tpls.min.js",
                      "~/Scripts/lib/jQuery/dist/jquery.min.js",
                      "~/Scripts/lib/bootstrap/dist/js/bootstrap.bundle.js"
                      ));

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
