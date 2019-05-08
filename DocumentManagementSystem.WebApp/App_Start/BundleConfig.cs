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
                      "~/Scripts/lib/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/Contents").IncludeDirectory(
                            "~/Content", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Scripts/lib/bootstrap/dist/css/*.css",
                        "~/styles/*.css"));
        }
    }
}
