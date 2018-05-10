var map;
var marker;

function setMarker(lat, lon) {
    map = null;
    setTimeout(function (){
    var getLocationMap = { lat: Number(lat.toFixed(3)), lng: Number(lon.toFixed(3)) };
    map = new google.maps.Map(document.getElementById('home_map_canvas'), {
        zoom: 2,
        center: getLocationMap
    });
    marker = new google.maps.Marker({
        map: map,
        position: getLocationMap,
        title: 'Was here!'
    });
    marker.setMap(map);
    }, 500);
}


var toDecimal = function (number) {
    return number[0].numerator + number[1].numerator /
        (60 * number[1].denominator) + number[2].numerator / (3600 * number[2].denominator);
};