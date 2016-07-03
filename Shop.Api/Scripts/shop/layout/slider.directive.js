(function (app) {
    'use strict';
    app.directive('footeBar', footeBar);
    function footeBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/shop/layout/footer.html'
        }
    }
})(angular.module('common.ui'));