(function () {
    "use strict";
    angular.module("ecomApp", ['common.core', 'common.ui'])
    .config(config)
    .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $$routeProvider
        .when("/", {
            templateUrl: "/scripts/spa/home/index.html",
            controller: "indexCtrl"
        })
        .when()
        .when()
        .otherwise({ redirectTo: "/" });

         
    }
})();