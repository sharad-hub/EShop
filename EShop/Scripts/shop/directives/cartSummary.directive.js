(function (app) {
    'use strict';
    app.directive('cartSummary', cartSummary);
    //.directive("cartSummary", 
    function cartSummary(cartService) {
        return {
            restrict: "E",
            replace:true,
            templateUrl: "/scripts/shop/directives/cartSummary.html",
            controller: function ($scope,$rootScope) {
                var cartData = cartService.getProducts();
                $scope.total = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += (cartData[i].price * cartData[i].count);
                    }
                    return total;
                }
                $rootScope.total = $scope.total();
                $scope.itemCount = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += cartData[i].count;
                    }
                    return total;
                }
                $scope.cartItems = cartData;
                $scope.cartShow = function ()
                {
                    $(".aa-cartbox-summary").css("display", "block");
                }
                $scope.cartHide = function () {
                    $(".aa-cartbox-summary").css("display", "none");
                }
                $scope.removeProduct = function (id) {
                    cartService.removeProduct(id);
                }
            }
        };
    }
})(angular.module('common.core'));