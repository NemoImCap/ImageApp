function selectImage($http, appSettings, imageService, exifService) {
    return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            elem.on("click", function (evt) {
                if (attr.id != null) {
                    imageService.GetImageById(attr.id).then(function (response) {
                        exifService.exif.getData(response.data, function () {
                            var coord = exifService.calculateGeoCoordinates(this);
                            exifService.setImageSrc(response.data);
                            var isExifCord = !angular.isUndefined(coord.latit) || !angular.isUndefined(coord.lon);
                            if (isExifCord) {
                                setMarker(toDecimal(coord.latit), toDecimal(coord.lon));
                            }
                            scope.$parent.showMap = isExifCord;
                            scope.$parent.uploadedFile = this;
                            scope.$parent.showExif = angular.equals(scope.uploadedFile.exifdata, {});
                            scope.$apply();
                        });
                    });
                }
            });
        }
    }
}