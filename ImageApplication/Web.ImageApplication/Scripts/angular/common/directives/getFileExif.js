function getFileExif(exifService) {
    return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            elem.on("change", function (evt) {
                exifService.exif.getData(evt.target.files[0], function () {
                    var coord = exifService.calculateGeoCoordinates(this);
                    var isExifCord = !angular.isUndefined(coord.latit) || !angular.isUndefined(coord.lon);
                    if (isExifCord) {
                        setMarker(toDecimal(coord.latit), toDecimal(coord.lon));
                    }
                    exifService.setImageSrc(evt.target.files[0]);
                    scope.uploadedFile = this;
                    scope.showMap = isExifCord;
                    scope.showExif = angular.equals(scope.uploadedFile.exifdata, {});
                    scope.updateModel.description = "";
                    scope.updateModel.id = null;
                    scope.$apply();
                });
            });
        }
    }
}