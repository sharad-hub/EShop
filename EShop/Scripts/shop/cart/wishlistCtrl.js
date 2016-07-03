(function (app) {
    'use strict';

    app.controller('wishlistCtrl', wishlistCtrl);

    wishlistCtrl.$inject = ['$scope', 'apiService', 'cartService', 'notificationService'];

    function wishlistCtrl($scope, apiService, cartService, notificationService) {
        //$scope.pageClass = 'page-home';
        //$scope.loadingproducts = true;
        //// $scope.loadingGenres = true;
        //$scope.isReadOnly = true;
        //$scope.filterProduct = '';
        
        //$scope.loadData = loadData;
        //var config = {
        //    params: {
        //        pageNo: 1,
        //        pageSize: 8,
        //        //filter: $scope.filterProduct
        //    }
        //};
        $scope.wishlistItems = [];
        $scope.AddToCart = function (product) {
            cartService.addProduct(product.id, product.name, product.price);
        }
        function loadData()
        {
            $scope.wishlistItems = cartService.getWishlistData();
        }
        loadData();
    }

})(angular.module('ecomApp'));