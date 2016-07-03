(function (app) {

    app.factory('apiService', apiService)
    apiService.$inject('$http', '$location', '$rootScope')
    function apiService()
    { }
})();