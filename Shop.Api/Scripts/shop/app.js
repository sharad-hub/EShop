(function () {
    "use strict";
    angular.module("ecomApp", ['common.core', 'common.ui'])
    .config(config)
    .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $$routeProvider
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
                 templateUrl: "/scripts/spa/products/products.html",
                 controller: "productCtrl"
             })
        .when()
        .when()
        .otherwise({ redirectTo: "/" });

    }
})();