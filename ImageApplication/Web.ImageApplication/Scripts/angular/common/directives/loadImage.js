function loadImage(imageService, exifService) {
    return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            if (attr.id != null) {
                imageService.GetImageById(attr.id).then(function(response) {
                    exifService.exif.getData(response.data, function () {
                        var output = document.getElementById(attr.id);
                        output.src = URL.createObjectURL(response.data);
                    });
                });
            }
        }
    }
}