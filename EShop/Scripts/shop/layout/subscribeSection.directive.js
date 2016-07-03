(function (app) {
    'use strict';
    app.directive('subscribeSection', subscribeSection);
    function subscribeSection() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/shop/layout/subscribeSection.html'
        }
    }
})(angular.module('common.ui'));