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
            bundles.Add(new ScriptBundle("~/jquery").Include("~/content/scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bootstrap").Include("~/content/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/angularJs").Include("~/content/scripts/angular.js",
                "~/content/scripts/angular-route.js",
                "~/JavaScript/app.js"));

            bundles.Add(new ScriptBundle("~/angularJs-products").Include(
              "~/JavaScript/Products/products-controller.js",
              "~/JavaScript/Products/products-service.js"));

            bundles.Add(new StyleBundle("~/bootstrap").Include(
              "~/content/css/bootstrap.css",
              "~/content/css/bootstrap-theme.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}