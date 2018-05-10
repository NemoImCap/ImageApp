function AppController(
    $scope,
    $http,
    imageService,
    appSettings,
    exifService,
    $filter,
    $timeout) {

    $scope.search = null;
    $scope.showMap = false;
    $scope.showExif = false;
    $scope.uploadedFile = null;
    $scope.updateFlag = false;
    $scope.updateModel = {
        id: null,
        description: ""
    }
    $scope.images = [];
    $scope.init = function () {
        $scope.loadImages();
    }

    $scope.loadImages = function () {
        var request = imageService.GetAllImages().then(function (response) {
            $scope.dataLoaded(response.data);
        });
    }

    $scope.dataLoaded = function (data) {
        $scope.images = data;
        if ($scope.images.length) {
            $scope.sendDescription($scope.images[0]);
            imageService.GetImageById($scope.updateModel.id).then(function (response) {
                exifService.exif.getData(response.data, function () {
                    var coord = exifService.calculateGeoCoordinates(this);
                    exifService.setImageSrc(response.data);
                    $scope.showMap = !angular.isUndefined(coord.latit) || !angular.isUndefined(coord.lon)
                    if ($scope.showMap) {
                        setMarker(toDecimal(coord.latit), toDecimal(coord.lon));
                    }
                    $scope.uploadedFile = response.data;
                    $scope.showExif = angular.equals($scope.uploadedFile.exifdata, {});
                });
            });
        }
    }

    $scope.sendDescription = function (item) {
        $scope.updateModel.description = item.Description || "";
        $scope.updateModel.id = item.Id;
    }

    $scope.updateImageDescription = function () {
        var request = imageService.UpdateDescription($scope.updateModel);
        request.then(function (response) {
            $scope.updateFlag = true;
            var found = $filter('filter')($scope.images, { Id: $scope.updateModel.id }, true);
            if (found.length) {
                found[0].Description = $scope.updateModel.description;
            }
            $timeout(function () {
                $scope.updateFlag = false;
            }, 2000);

        });
    }

    $scope.init();
};
