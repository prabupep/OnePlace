using System.Web;
using System.Web.Optimization;

namespace OnePlace.Web
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
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                        "~/Scripts/AngularJS/angular.1.6.9.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/FullCalendar/css").Include(
                "~/Content/Fullcalendar/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Application-main").Include(
                "~/Scripts/Application/applicationconstants.js"
                , "~/Scripts/Application/main.js"));

            bundles.Add(new ScriptBundle("~/application/release-detail").Include("~/Scripts/Application/release-detail.js"));
            bundles.Add(new ScriptBundle("~/application/release-list").Include("~/Scripts/Application/release-list.js"));
            bundles.Add(new ScriptBundle("~/application/project-detail").Include("~/Scripts/Application/projects.js"));
            bundles.Add(new ScriptBundle("~/application/setup-languages").Include("~/Scripts/Application/languages.js"));
            bundles.Add(new ScriptBundle("~/Moment/moment").Include("~/Scripts/Moment/moment.js"));
            bundles.Add(new ScriptBundle("~/Fullcalendar/fullcalendar").Include("~/Scripts/Fullcalendar/fullcalendar.min.js"));
            bundles.Add(new ScriptBundle("~/Application/fullcalendar").Include("~/Scripts/Application/calendarpage.js"));


        }
    }
}
