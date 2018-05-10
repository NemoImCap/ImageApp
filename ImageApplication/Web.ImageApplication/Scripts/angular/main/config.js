var app = angular.module("app", ['core']);


//Controllers
app.controller('AppController', AppController);


AppController.$inject = ['$scope', '$http', 'imageService', 'appSettings', 'exifService', '$filter', '$timeout'];


/* Core Module Config
-----------------------------------------------------------------------------------------------------------------*/



