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
            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                      "~/Content/controllers/*.js"));
            bundles.Add(new ScriptBundle("~/bundles/directive").Include(
                      "~/Content/directives/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/lib/jQuery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/lib/bootstrap/dist/js/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Scripts/lib/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/less").Include("~/Scripts/lib/less/dist/less.js"));           
        }
    }
}
