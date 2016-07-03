using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SPA.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                //"~/Scripts/Vendors/jquery.js",
                //"~/Scripts/Vendors/bootstrap.js",
               
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
                "~/Scripts/Vendors/angular-ui/ui-bootstrap.js",
                //"~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/ADMJs").Include(
   "~/Scripts/Vendors/jquery.js",
              "~/ADM_LTE/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
              "~/ADM_LTE/plugins/morris/morris.min.js",
              "~/ADM_LTE/plugins/sparkline/jquery.sparkline.min.js",
              "~/ADM_LTE/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
              "~/ADM_LTE/plugins/knob/jquery.knob.js",
              "~/ADM_LTE/plugins/daterangepicker/daterangepicker.js",
              "~/ADM_LTE/plugins/datepicker/bootstrap-datepicker.js",
              "~/ADM_LTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
              "~/ADM_LTE/plugins/slimScroll/jquery.slimscroll.min.js",
              "~/ADM_LTE/plugins/fastclick/fastclick.min.js"
              ));


            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/services/fileUploadService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/sideBar.directive.js",
                "~/Scripts/spa/layout/customPager.directive.js",
                "~/Scripts/spa/directives/rating.directive.js",
                "~/Scripts/spa/directives/availableMovie.directive.js",
                "~/Scripts/spa/account/loginCtrl.js",
                "~/Scripts/spa/account/registerCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",

                  "~/Scripts/spa/products/productGrid.js",
                "~/Scripts/spa/products/productsCtrl.js",
                "~/Scripts/spa/products/productAddCtrl.js",
                "~/Scripts/spa/products/productEditCtrl.js",

                  "~/Scripts/spa/customers/customersCtrl.js",
                "~/Scripts/spa/customers/customersRegCtrl.js",
                "~/Scripts/spa/customers/customerEditCtrl.js",

                "~/Scripts/spa/movies/moviesCtrl.js"
                //"~/Scripts/spa/movies/movieAddCtrl.js",
                //"~/Scripts/spa/movies/movieDetailsCtrl.js",
                //"~/Scripts/spa/movies/movieEditCtrl.js",
                //"~/Scripts/spa/controllers/rentalCtrl.js",
                //"~/Scripts/spa/rental/rentMovieCtrl.js",
                //"~/Scripts/spa/rental/rentStatsCtrl.js"                
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

                 "~/Scripts/shop/products/productGrid.js",
               "~/Scripts/shop/products/productsCtrl.js",
               "~/Scripts/shop/products/productAddCtrl.js",
               "~/Scripts/shop/products/productEditCtrl.js",

                 "~/Scripts/shop/customers/customersCtrl.js",
               "~/Scripts/shop/customers/customersRegCtrl.js",
               "~/Scripts/shop/customers/customerEditCtrl.js",
               "~/Scripts/shop/movies/moviesCtrl.js"

               ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/site.css",
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css",
                 "~/content/css/font-awesome.css",
                "~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css"));

            


            bundles.Add(new StyleBundle("~/Content/ecomcss").Include(
             "~/content/Ecom/css/font-awesome.css",
             "~/content/Ecom/css/jquery.smartmenus.bootstrap.css",
             "~/content/Ecom/css/bootstrap.css",
             "~/content/Ecom/css/jquery.simpleLens.css",
              "~/content/Ecom/css/slick.css",
             "~/content/Ecom/css/nouislider.css",
             "~/content/Ecom/css/theme-color/default-theme.css",
             "~/content/Ecom/css/sequence-theme.modern-slide-in.css",
             "~/content/Ecom/css/style.css"));
        }

    }
}