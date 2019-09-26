
//<!-------------------------------------------Map Script---------------------------------->


//<!-----------------------------------Old Map------------------>
//$(
//    function myMap() {
//        var myCenter = new google.maps.LatLng(16.803267, 96.137586);
//        var mapProp = { center: myCenter, zoom: 15, scrollwheel: false, draggable: true, mapTypeId: google.maps.MapTypeId.TERRAIN };
//        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
//        var marker = new google.maps.Marker({ position: myCenter });

//        marker.setMap(map);
//    }
//    );

//<!-------------------------------------------Map Script---------------------------------->
var locations = [
    ['Botahtaung', 16.766441, 96.172558],
    ['People Park', 16.801424, 96.139556],
    ['Shwedagon Pagoda', 16.798336, 96.149314],
    ['Gallery Cafe, Kabar Aye Pagoda Road', 16.809126, 96.154043],
    ['Mahar Bandula Park', 16.773140, 96.159216],
    ['SEEDS Restaurant & Lounge', 16.846943, 96.152468],
    ['Ayetharyar Wine Garden', 20.777358, 96.998626],
    ['Sulamani Pagoda Taunggyi', 20.764368, 97.046299],
    ['Taunggyi', 20.728495, 97.065518],
    ['Cafe in town', 16.772171, 96.161346],
    ['Cafe Debar', 16.803025, 96.132484],
    ['Kai Li Chicken Hot Pot', 16.829876, 96.150895],
    
];

//$(
//    function myMap() {
//        var myCenter = new google.maps.LatLng(16.803267, 96.137586);
//        var mapProp = { center: myCenter, zoom: 15, scrollwheel: false, draggable: true, mapTypeId: google.maps.MapTypeId.TERRAIN };
//        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
//        var infowindow = new google.maps.InfoWindow();
//        var marker, i;

//for (i = 0; i < locations.length; i++) {
//    marker = new google.maps.Marker({
//        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
//        map: map
//    });

//    google.maps.event.addListener(marker, 'click', (function (marker, i) {
//        return function () {
//            infowindow.setContent(locations[i][0]);
//            infowindow.open(map, marker);
//        }
//    })(marker, i));
//}
//    }
//    );

//My Location------------------------------------------

//if (navigator.geolocation) {
//    navigator.geolocation.getCurrentPosition(success);
//} else {
//    alert("There is Some Problem on your current browser to get Geo Location!");
//}

//function success(position) {
//    var lat = position.coords.latitude;
//    var long = position.coords.longitude;
//    var city = position.coords.locality;
//    var LatLng = new google.maps.LatLng(lat, long);
//    var mapOptions = {
//        center: LatLng,
//        zoom: 12,
//        mapTypeId: google.maps.MapTypeId.ROADMAP
//    };

//    var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);
//    var marker = new google.maps.Marker({
//        position: LatLng,
//        title: "<div style = 'height:60px;width:200px'><b>Your location:</b><br />Latitude: "
//            + lat + +"<br />Longitude: " + long
//    });

//    marker.setMap(map);
//    var getInfoWindow = new google.maps.InfoWindow({
//        content: "<b>Your Current Location</b><br/> Latitude:" +
//            lat + "<br /> Longitude:" + long + ""
//    });
//    getInfoWindow.open(map, marker);
//}  

//get direction------------------------------------------------

//if (navigator.geolocation) {
//    navigator.geolocation.getCurrentPosition(success);

//} else {
//    alert("There is Some Problem on your current browser to get Geo Location!");
//}

//function success(position) {
//    var lat = position.coords.latitude;
//    var long = position.coords.longitude;
//    var city = position.coords.locality;
//    var LatLng = new google.maps.LatLng(lat, long);
//    var mapOptions = {
//        center: LatLng,
//        zoom: 12,
//        mapTypeId: google.maps.MapTypeId.ROADMAP
//    };

//    var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);
//    for (i = 0; i < locations.length; i++) {
//        marker = new google.maps.Marker({
//            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
//            map: map
//        });
//        google.maps.event.addListener(marker, 'click', (function (marker, i) {
//            return function () {
//                getInfoWindow.setContent(locations[i][0]);
//                getInfoWindow.open(map, marker);
//            }
//        })(marker, i));
      
//    }
//    var marker = new google.maps.Marker({
//        position: LatLng,
//        title: "<div style = 'height:60px;width:200px'><b>Your location:</b><br />Latitude: "
//            + lat + +"<br />Longitude: " + long
//    });

//    marker.setMap(map);
//    var getInfoWindow = new google.maps.InfoWindow({
//        content: "<b>Your Current Location</b><br/> Latitude:" +
//            lat + "<br /> Longitude:" + long + ""
//    });
//    getInfoWindow.open(map, marker);

//}

//function SearchRoute() {
//    document.getElementById("googleMap").style.display = 'none';

//    var markers = new Array();
//    var myLatLng;

//    //Find the current location of the user.
//    if (navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(function (p) {
//            var myLatLng = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
//            var m = {};
//            m.title = "Your Current Location";
//            m.lat = p.coords.latitude;
//            m.lng = p.coords.longitude;
//            markers.push(m);

//            //Find Destination address location.
//            var address = document.getElementById("txtDestination").value;
//            var geocoder = new google.maps.Geocoder();
//            geocoder.geocode({ 'address': address }, function (results, status) {
//                if (status == google.maps.GeocoderStatus.OK) {
//                    m = {};
//                    m.title = address;
//                    m.lat = results[0].geometry.location.lat();
//                    m.lng = results[0].geometry.location.lng();
//                    markers.push(m);
//                    var mapOptions = {
//                        center: myLatLng,
//                        zoom: 4,
//                        mapTypeId: google.maps.MapTypeId.ROADMAP
//                    };
//                    var map = new google.maps.Map(document.getElementById("MapRoute"), mapOptions);
//                    var infoWindow = new google.maps.InfoWindow();
//                    var lat_lng = new Array();
//                    var latlngbounds = new google.maps.LatLngBounds();

//                    for (i = 0; i < markers.length; i++) {
//                        var data = markers[i];
//                        var myLatlng = new google.maps.LatLng(data.lat, data.lng);
//                        lat_lng.push(myLatlng);
//                        var marker = new google.maps.Marker({
//                            position: myLatlng,
//                            map: map,
//                            title: data.title
//                        });
//                        latlngbounds.extend(marker.position);
//                        (function (marker, data) {
//                            google.maps.event.addListener(marker, "click", function (e) {
//                                infoWindow.setContent(data.title);
//                                infoWindow.open(map, marker);
//                            });
//                        })(marker, data);
//                    }
//                    map.setCenter(latlngbounds.getCenter());
//                    map.fitBounds(latlngbounds);


//                    //Initialize the Path Array.
//                    var path = new google.maps.MVCArray();

//                    //Getting the Direction Service.
//                    var service = new google.maps.DirectionsService();

//                    //Set the Path Stroke Color.
//                    var poly = new google.maps.Polyline({ map: map, strokeColor: '#4986E7' });

//                    //Loop and Draw Path Route between the Points on MAP.
//                    for (var i = 0; i < lat_lng.length; i++) {
//                        if ((i + 1) < lat_lng.length) {
//                            var src = lat_lng[i];
//                            var des = lat_lng[i + 1];
//                            path.push(src);
//                            poly.setPath(path);
//                            service.route({
//                                origin: src,
//                                destination: des,
//                                travelMode: google.maps.DirectionsTravelMode.DRIVING
//                            }, function (result, status) {
//                                if (status == google.maps.DirectionsStatus.OK) {
//                                    for (var i = 0, len = result.routes[0].overview_path.length; i < len; i++) {
//                                        path.push(result.routes[0].overview_path[i]);
//                                    }

//                                } else {
//                                    alert("Invalid location.");
//                                    window.location.href = window.location.href;
//                                }
//                            });
//                        }
//                    }
//                } else {
//                    alert("Request failed.")
//                    window.location.href = window.location.href;
//                }
//            });

//        });
//    }
//    else {
//        alert('Some Problem in getting Geo Location.');
//        return;
//    }
//}

//-------------------------------------------------------------------------------
var map;
var faisalabad = { lat: 16.805733, lng: 96.135499 };


function addYourLocationButton(map, marker) {
    var controlDiv = document.createElement('div');

    var firstChild = document.createElement('button');
    firstChild.style.backgroundColor = '#fff';
    firstChild.style.border = 'none';
    firstChild.style.outline = 'none';
    firstChild.style.width = '30px';
    firstChild.style.height = '30px';
    firstChild.style.borderRadius = '2px';
    firstChild.style.boxShadow = '0 1px 4px rgba(0,0,0,0.3)';
    firstChild.style.cursor = 'pointer';
    firstChild.style.marginRight = '10px';
    firstChild.style.padding = '0px';
    firstChild.title = 'Your Location';
    controlDiv.appendChild(firstChild);

    var secondChild = document.createElement('div');
    secondChild.style.margin = '5px';
    secondChild.style.width = '18px';
    secondChild.style.height = '18px';
    secondChild.style.backgroundImage = 'url(https://maps.gstatic.com/tactile/mylocation/mylocation-sprite-1x.png)';
    secondChild.style.backgroundSize = '180px 18px';
    secondChild.style.backgroundPosition = '0px 0px';
    secondChild.style.backgroundRepeat = 'no-repeat';
    secondChild.id = 'you_location_img';
    firstChild.appendChild(secondChild);


    google.maps.event.addListener(map, 'dragend', function () {
        $('#you_location_img').css('background-position', '0px 0px');
    });

    firstChild.addEventListener('click', function () {
        var imgX = '0';
        var animationInterval = setInterval(function () {
            if (imgX == '-18') imgX = '0';
            else imgX = '-18';
            $('#you_location_img').css('background-position', imgX + 'px 0px');
        }, 500);
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                marker.setPosition(latlng);
                map.setCenter(latlng);
                clearInterval(animationInterval);
                
                $('#you_location_img').css('background-position', '-144px 0px');
            });
        }
        else {
            clearInterval(animationInterval);
            $('#you_location_img').css('background-position', '0px 0px');
        }
    });

    controlDiv.index = 1;
    map.controls[google.maps.ControlPosition.RIGHT_BOTTOM].push(controlDiv);
}
function SearchRoute() {
    //document.getElementById("googleMap").style.display = 'none';

    var markers = new Array();
    var myLatLng;

    //Find the current location of the user.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (p) {
            var myLatLng = new google.maps.LatLng(p.coords.latitude, p.coords.longitude);
            var m = {};
            m.title = "Your Current Location";
            m.lat = p.coords.latitude;
            m.lng = p.coords.longitude;
            markers.push(m);

            //Find Destination address location.
            var address = document.getElementById("txtDestination").value;
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    m = {};
                    m.title = address;
                    m.lat = results[0].geometry.location.lat();
                    m.lng = results[0].geometry.location.lng();
                    markers.push(m);
                    var mapOptions = {
                        center: myLatLng,
                        zoom: 4,

                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };
                    var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);
                    var infoWindow = new google.maps.InfoWindow();
                    var lat_lng = new Array();
                    var latlngbounds = new google.maps.LatLngBounds();

                    for (i = 0; i < markers.length; i++) {
                        var data = markers[i];
                        var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                        lat_lng.push(myLatlng);
                        var marker = new google.maps.Marker({
                            position: myLatlng,
                            map: map,
                            title: data.title
                        });
                        latlngbounds.extend(marker.position);
                        (function (marker, data) {
                            google.maps.event.addListener(marker, "click", function (e) {
                                infoWindow.setContent(data.title);
                                infoWindow.open(map, marker);
                            });
                        })(marker, data);
                    }
                    map.setCenter(latlngbounds.getCenter());
                    map.fitBounds(latlngbounds);


                    //Initialize the Path Array.
                    var path = new google.maps.MVCArray();

                    //Getting the Direction Service.
                    var service = new google.maps.DirectionsService();

                    //Set the Path Stroke Color.
                    var poly = new google.maps.Polyline({ map: map, strokeColor: '#4986E7' });

                    //Loop and Draw Path Route between the Points on MAP.
                    for (var i = 0; i < lat_lng.length; i++) {
                        if ((i + 1) < lat_lng.length) {
                            var src = lat_lng[i];
                            var des = lat_lng[i + 1];
                            path.push(src);
                            poly.setPath(path);
                            service.route({
                                origin: src,
                                destination: des,
                                travelMode: google.maps.DirectionsTravelMode.DRIVING
                            }, function (result, status) {
                                if (status == google.maps.DirectionsStatus.OK) {
                                    for (var i = 0, len = result.routes[0].overview_path.length; i < len; i++) {
                                        path.push(result.routes[0].overview_path[i]);
                                    }

                                } else {
                                    alert("Invalid location.");
                                    window.location.href = window.location.href;
                                }
                            });
                        }
                    }
                } else {
                    alert("Request failed.")
                    window.location.href = window.location.href;
                }
            });

        });
    }
    else {
        alert('Some Problem in getting Geo Location.');
        return;
    }

}


function initMap() {
    map = new google.maps.Map(document.getElementById('googleMap'), {
        zoom: 15,
        center: faisalabad
    });
    for (i = 0; i < locations.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            map: map
        });
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                getInfoWindow.setContent(locations[i][0]);
                getInfoWindow.open(map, marker);
            }
        })(marker, i));
    }
    marker.setMap(map);
    var getInfoWindow = new google.maps.InfoWindow({
        position: faisalabad
    });
    getInfoWindow.open(map, marker);
   
    var myMarker = new google.maps.Marker({
        map: map,
        animation: google.maps.Animation.DROP,
        position: faisalabad
    });
    addYourLocationButton(map, myMarker);
   
}

$(document).ready(function (e) {
    initMap();
});

