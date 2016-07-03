(function (app) {
    'use strict';
    app.controller('loginCtrl', loginCtrl);
    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService','$rootScope', '$location'];
    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};

        function login() {
            membershipService.login($scope.user, loginCompleted)
        }

        function loginCompleted(result) {
            if (result.data.success) {
                console.log(result);
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Hello ' + $scope.user.username);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/');
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }
        }
      
        $scope.register = register;
        $scope.newUser = {};

        function register() {
            membershipService.register($scope.newUser, registerCompleted)
        }

        function registerCompleted(result) {
            if (result.data.success) {
                console.log(result);
                membershipService.saveCredentials($scope.newUser);
                notificationService.displaySuccess('Hello ' + $scope.newUser.username);
                $scope.userData.displayUserInfo();
                $location.path('/');
            }
            else {
                console.log('register error' );
                notificationService.displayError('Registration failed. Try again.');
            }
        }


    }
})(angular.module('common.core'));