(function (app) {
    'use strict';

    app.controller('checkoutCtrl', checkoutCtrl);

    checkoutCtrl.$inject = ['$scope', '$rootScope', 'apiService', 'cartService', 'notificationService'];

    function checkoutCtrl($scope, $rootScope, apiService, cartService, notificationService) {

        $scope.cartItems = [];
        $scope.loadData = loadData;
        var config = {
            params: {
                pageNo: 1,
                pageSize: 8,
                //filter: $scope.filterProduct
            }
        };
        $scope.AddToCart = function (product) {
            cartService.addProduct(product.ProductID, product.ProductName, product.UnitPrice);
        }
        $scope.RemoveFrmCart = function (id) {
            cartService.removeProduct(id);
        }
        function loadData() {
            $scope.cartItems = cartService.getProducts();
        }
        $scope.cartTotal = 0;
        $scope.tax = 34;
        $scope.total = function () {
            var total = 0;
            for (var i = 0; i < $scope.cartItems.length; i++) {
                total += ($scope.cartItems[i].price * $scope.cartItems[i].count);
            }
            $scope.cartTotal = total;
            return total;
        }
        $scope.$watchCollection('$scope.cartItems', function () {
            $scope.total();
        });
        $scope.itemCount = function () {
            var total = 0;
            for (var i = 0; i < $scope.cartItems.length; i++) {
                total += $scope.cartItems[i].count;
            }
            return total;
        }
        $scope.subTotal = function () {
            return  $scope.cartTotal + $scope.tax;
        }
        
        loadData();
    }

})(angular.module('ecomApp'));