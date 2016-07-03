(function (app) {
    'use strict';
    app.directive('mainNav', mainNav);
    function mainNav() {
        return {
            restrict: 'E',
            replace: true,
            //scope: {
            //   // loc: '@location',
            //    menus: '='
            //},
            //link: function ($scope, $element) {

            //},
            templateUrl: '/scripts/shop/layout/mainNav.html'
        }
    }
})(angular.module('common.ui'));