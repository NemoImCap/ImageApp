function exifService() {
    var self = {
        exif: EXIF,
        coordinates: null
    };

    self.calculateGeoCoordinates = function (obj) {
        var lon = this.exif.getTag(obj, 'GPSLongitude');
        var latit = this.exif.getTag(obj, 'GPSLatitude');
        return { lon: lon, latit: latit };
    }

    self.setImageSrc = function (response) {
        var output = document.getElementById('blah');
        output.src = URL.createObjectURL(response);
        output.className = '';
    }

    return self;
}