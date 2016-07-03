(function (app) {
    'use strict';
    app.directive('sliderBar', sliderBar);
    function sliderBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/shop/layout/slider.html'
        }
    }
})(angular.module('common.ui'));