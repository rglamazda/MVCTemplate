using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApi
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jquery/js").Include("~/content/script/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include("~/content/script/bootstrap.js"));
          
            bundles.Add(new ScriptBundle("~/angular/js").Include("~/content/script/angular.js", 
                "~/content/script/angular-route.js",
                "~/JavaScript/app.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
              "~/content/css/bootstrap.css",
              "~/content/css/bootstrap-theme.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}