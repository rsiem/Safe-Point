﻿using System.Web;
using System.Web.Optimization;

namespace SafePoint
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                      "~/Content/smalot-datetimepicker/bootstrap-datetimepicker.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css"
            ));

            // Add the location.js to the bundle called mapbox
            bundles.Add(new ScriptBundle("~/bundles/mapbox").Include(
                      "~/Scripts/location.js"));

            // Add the data table bundle
            bundles.Add(new StyleBundle("~/bundles/DataTables").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js"));

            // Add the datetimepicker bundle
            bundles.Add(new StyleBundle("~/bundles/datetimepicker").Include(
                //"~/Scripts/smalot-datetimepicker/bootstrap-datetimepicker.js",
                "~/Scripts/smalot-datetimepicker.js",
                "~/Scripts/datetimepicker.js"
                ));
        }
    }
}
