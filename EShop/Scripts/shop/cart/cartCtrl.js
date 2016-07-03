(function (app) {
    'use strict';

    app.controller('cartCtrl', cartCtrl);

    cartCtrl.$inject = ['$scope','$rootScope', 'apiService', 'cartService', 'notificationService'];

    function cartCtrl($scope,$rootScope, apiService, cartService, notificationService) {
 
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

        loadData();
    }

})(angular.module('ecomApp'));