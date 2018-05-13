using System.Web.Optimization;

namespace Web.ImageApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string ANGULAR_APP_ROOT = "~/Scripts/angular/";
            const string ANGULAR_VENDORS_ROOT = "~/Assets/framework/";
            const string ANGULAR_MAIN = "~/Scripts/angular/main/";


            //Angular init 
            bundles.Add(new ScriptBundle("~/Angular/").Include(ANGULAR_VENDORS_ROOT + "angular/angular.min.js")
                .Include(ANGULAR_VENDORS_ROOT + "angular-ui-bs/ui-bootstrap-2.5.0.min.js")
                .IncludeDirectory(ANGULAR_VENDORS_ROOT, "*.js", true));
            bundles.Add(new ScriptBundle("~/AngularApp/").IncludeDirectory(ANGULAR_MAIN, "*.js", true));
            bundles.Add(new ScriptBundle("~/AngularScript/")
                .IncludeDirectory(ANGULAR_APP_ROOT + "common/", "*.js", true)
                .IncludeDirectory(ANGULAR_APP_ROOT + "controllers/", "*.js", true));


            bundles.Add(new ScriptBundle("~/Assets/plugins").Include(
                "~/Assets/exif/exif.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/animate.min.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-1.12.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}