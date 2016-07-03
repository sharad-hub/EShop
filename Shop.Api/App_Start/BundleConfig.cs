using System.Web;
using System.Web.Optimization;

namespace Shop.Api
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/bootstrap.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/Vendors/respond.src.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",
                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/raphael.js",
                "~/Scripts/Vendors/morris.js",
                //"~/Scripts/Vendors/jquery.fancybox.js",
                //"~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/shop").Include(
               "~/Scripts/shop/modules/common.core.js",
               "~/Scripts/shop/modules/common.ui.js",
               "~/Scripts/shop/app.js",
               "~/Scripts/shop/services/apiService.js",
               "~/Scripts/shop/services/notificationService.js",
               "~/Scripts/shop/services/membershipService.js",
               "~/Scripts/shop/services/fileUploadService.js",
               "~/Scripts/shop/layout/topBar.directive.js",
               "~/Scripts/shop/layout/sideBar.directive.js",
               "~/Scripts/shop/layout/footer.directive.js",
               "~/Scripts/shop/layout/header.directive.js",
               "~/Scripts/shop/layout/mainNav.directive.js",
               "~/Scripts/shop/layout/slider.directive.js",
               "~/Scripts/shop/directives/rating.directive.js",
               "~/Scripts/shop/directives/availableMovie.directive.js",
               "~/Scripts/shop/account/loginCtrl.js",
               "~/Scripts/shop/account/registerCtrl.js",
               "~/Scripts/shop/home/rootCtrl.js",
               "~/Scripts/shop/home/indexCtrl.js",

                 "~/Scripts/spa/products/productGrid.js",
               "~/Scripts/spa/products/productsCtrl.js",
               "~/Scripts/spa/products/productAddCtrl.js",
               "~/Scripts/spa/products/productEditCtrl.js",

                 "~/Scripts/spa/customers/customersCtrl.js",
               "~/Scripts/spa/customers/customersRegCtrl.js",
               "~/Scripts/spa/customers/customerEditCtrl.js",
               "~/Scripts/spa/movies/moviesCtrl.js"
                           
               ));
            bundles.Add(new StyleBundle("~/Content/ecomcss").Include(
             "~/content/css/font-awesome.css",
             "~/content/css/jquery.smartmenus.bootstrap.css",
             "~/content/css/bootstrap.css",
             "~/content/Ecom/css/jquery.simpleLens.css",
              "~/content/Ecom/css/slick.css",
             "~/content/Ecom/css/nouislider.css",
             "~/content/Ecom/css/theme-color/default-theme.css",
             "~/content/Ecom/css/sequence-theme.modern-slide-in.css",
             "~/content/Ecom/css/style.css"));
        }
    }
}
