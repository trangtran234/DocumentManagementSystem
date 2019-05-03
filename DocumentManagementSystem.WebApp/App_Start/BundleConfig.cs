using System.Web;
using System.Web.Optimization;

namespace DocumentManagementSystem.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/lib/angular/angular.min.js", "~/Content/*.js"));
        }
    }
}
