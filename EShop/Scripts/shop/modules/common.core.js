(function(){
	"use strict";
	angular.module('common.core', ['ngRoute', 'ngCookies', 'base64', 'angularFileUpload', 'angularValidator', 'angucomplete-alt', 'ngStorage'])
    .config(['$localStorageProvider',
    function ($localStorageProvider) {
        $localStorageProvider.setKeyPrefix('items');
    }])

})();