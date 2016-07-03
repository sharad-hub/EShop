//(function (app) {
//    'use strict';
//    app.directive('footerxBar', footerxBar);
//    function footerxBar() {
//        return {
//            restrict: 'E',
//            replace: true,
//            templateUrl: '/scripts/shop/layout/footer.html'
//        }
//    }
//})(angular.module('common.ui'));

(function (app) {
    'use strict';
    app.directive('footerxBar', footerxBar);
    function footerxBar() {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/shop/layout/footer.html'
        }
    }
})(angular.module('common.ui'));