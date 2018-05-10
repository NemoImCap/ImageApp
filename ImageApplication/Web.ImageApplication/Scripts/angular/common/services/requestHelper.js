function requestHelper($http, $q, appSettings, $window) {
    var api = {};

    api.get = function (url, params, config) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url + params;
        $http({
            method: 'GET',
            url: apiUrl,
            responseType: config || ""
        }).then(function (response) {
            deferred.resolve(response);
        },
            function (response) {
                deferred.reject(response);
            });
        return deferred.promise;
    },


    api.post = function (url, params, userConfig) {
        var deferred = $q.defer();
        var apiUrl = appSettings.serviceUrl($window.location.href) + url;
        var options = {
            method: 'POST',
            url: apiUrl,
            headers: {
                'Content-Type': undefined
            },
            data: params
            //data: JSON.stringify(params),
        }
        var opt = angular.extend(options, userConfig);
        $http(opt)
           .then(function (response) {
               deferred.resolve(response);
           },
                function (response) {
                    deferred.reject(response);
                });
        return deferred.promise;
    }
    return api;
};
