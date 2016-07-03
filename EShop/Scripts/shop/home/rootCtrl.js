(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope' , '$location', 'membershipService','apiService' ,'$rootScope'];
    function rootCtrl($scope, $location, membershipService, apiService, $rootScope) {

        $scope.userData = {};

        $scope.userData.displayUserInfo = displayUserInfo;
        $scope.logout = logout;


        function displayUserInfo() {
            $scope.userData.isUserLoggedIn = membershipService.isUserLoggedIn();

            if ($scope.userData.isUserLoggedIn) {
                $scope.username = $rootScope.repository.loggedUser.username;
            }
        }

        function logout() {
            membershipService.removeCredentials();
            $location.path('#/');
            $scope.userData.displayUserInfo();
        }

        $scope.userData.displayUserInfo();


        $scope.items = ['item1', 'item2', 'item3'];

        $scope.animationsEnabled = true;   

        function loadData() {
            apiService.get('http://eshop.co.in/EShop.Services/api/MenuApi', null,
                        menusLoadCompleted,
                        menusLoadFailed);
        }
        loadData();
        function menusLoadCompleted(result) {          
            $scope.menus = result.data;
            $scope.loadingmenus = false;
        }
        function menusLoadFailed() {
        }
    }

})(angular.module('ecomApp'));