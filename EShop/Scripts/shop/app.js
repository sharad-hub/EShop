(function () {
    "use strict";
    angular.module("ecomApp", ['common.core', 'common.ui'])
    .config(config)
    .run(run);
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "/scripts/shop/home/index.html",
            controller: "indexCtrl"
        }).when("/login", {
            templateUrl: "/scripts/shop/account/login.html",
            controller: "loginCtrl"
        })
            .when("/register", {
                templateUrl: "/scripts/shop/account/register.html",
                controller: "registerCtrl"
            })
             .when("/products", {
                 templateUrl: "/scripts/shop/products/products.html",
                 controller: "productCtrl"
             })
       .when("/Blog", {
           templateUrl: "/scripts/shop/pages/blog-archive-2.html",
           controller: "productCtrl"
       }).when("/blog/detail", {
           templateUrl: "/scripts/shop/pages/blog-single.html",
           controller: "productCtrl"
       }).when("/cart", {
           templateUrl: "/scripts/shop/cart/cart.html",
           controller: "cartCtrl"
       }).when("/wishlist", {
           templateUrl: "/scripts/shop/cart/wishlist.html",
           controller: "wishlistCtrl"
       }).when("/checkout", {
           templateUrl: "/scripts/shop/cart/checkout.html",
           controller: "checkoutCtrl"
       }).when("/account", {
           templateUrl: "/scripts/shop/account/account.html",
           controller: "accountCtrl"
       })

        //.when()
        .otherwise({ redirectTo: "/" });
    }
    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            //$(".fancybox").fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none'
            //});

            //$('.fancybox-media').fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none',
            //    helpers: {
            //        media: {}
            //    }
            //});

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();