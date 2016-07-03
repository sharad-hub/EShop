(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope','apiService','cartService', 'notificationService'];

    function indexCtrl($scope, apiService,cartService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingproducts = true;
       // $scope.loadingGenres = true;
        $scope.isReadOnly = true;
        $scope.filterProduct = '';
        $scope.productList = [];
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
        $scope.AddToCart = function (product) {
            cartService.addProduct(product.ProductID, product.ProductName, product.UnitPrice);
        }
        function loadData() {
            apiService.get('http://eshop.co.in/EShop.Services/api/ProductApi/GetProduct', config,
                        productsLoadCompleted,
                        productsLoadFailed);

            //apiService.get("/api/genres/", null,
            //    genresLoadCompleted,
            //    genresLoadFailed);
        }

        function productsLoadCompleted(result) {
            $scope.productList = result.data;           
            $scope.loadingproducts = false;
        }

        //function genresLoadFailed(response) {
        //    notificationService.displayError(response.data);
        //}

        function productsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        //function genresLoadCompleted(result) {
        //    var genres = result.data;
        //    Morris.Bar({
        //        element: "genres-bar",
        //        data: genres,
        //        xkey: "Name",
        //        ykeys: ["NumberOfMovies"],
        //        labels: ["Number Of Movies"],
        //        barRatio: 0.4,
        //        xLabelAngle: 55,
        //        hideHover: "auto",
        //        resize: 'true'
        //    });
        //    //.on('click', function (i, row) {
        //    //    $location.path('/genres/' + row.ID);
        //    //    $scope.$apply();
        //    //});

        //    $scope.loadingGenres = false;
        //}

        loadData();

       
    }

})(angular.module('ecomApp'));