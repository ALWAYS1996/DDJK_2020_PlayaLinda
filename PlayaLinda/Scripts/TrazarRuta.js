/* global google 9.628252, -84.626613 */

var map;
var america_lat = 9.7489166;
var america_lng = -83.7534256;


var directionDisplay = new google.maps.DirectionsRenderer({ polylineOptions: { strokeColor: '#2E9AFE' } });
var directionService = new google.maps.DirectionsService();



function start_map() {
   // document.getElementById('auto').style.display = 'none';
    $('#search').hide();
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: america_lat, lng: america_lng },
        zoom: 9
    });
    $('.autoclick').trigger('click');

}



function get_my_location() {
    //param ruta destino
    draw_rute_map(9.975507, -84.843421);
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            //  $('#my_lat').val(position.coords.latitude);
            //  $('#my_lng').val(position.coords.longitude);
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
                           //var marker= new google.maps.Marker({
                           // map: map,
                           // draggable:false,
                           // animation: google.maps.Animation.DROP,
                           // position :pos
                               
                           //});

            //8.820193, -82.973514 coordenadas de limon
        });
    }
}

function draw_rute_map(Lat, Lng) {
    //Param origen
    var my_lat = $('#my_lat').val();
    var my_lng = $('#my_lng').val();


    var start = new google.maps.LatLng(my_lat, my_lng);
    var end = new google.maps.LatLng(Lat, Lng);
    var request = {
        origin: start,
        destination: end,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionDisplay.setDirections(response);
            directionDisplay.setMap(map);
            directionDisplay.setOptions({ suppressMarkers: false });
        }
    });
}