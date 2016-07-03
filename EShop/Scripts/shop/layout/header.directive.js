(function (app) {
    'use strict';
    app.directive('headerBar', headerBar);
    function headerBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/shop/layout/header.html'
        }
    }
})(angular.module('common.ui'));