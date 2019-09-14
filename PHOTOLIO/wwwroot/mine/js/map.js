
//<!-------------------------------------------Map Script---------------------------------->

//$(
//    function myMap() {
//        var myCenter = new google.maps.LatLng(16.847940, 96.125031);
//        var mapProp = { center: myCenter, zoom: 16, scrollwheel: true, draggable: true, mapTypeId: google.maps.MapTypeId.TERRAIN };
//        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
//        var marker = new google.maps.Marker({ position: myCenter });
//        marker.setMap(map);
//    }
//);

//<!-------------------------------------------Map Script---------------------------------->

$(
    function myMap() {
        var myCenter = new google.maps.LatLng(16.803267, 96.137586);
        var mapProp = { center: myCenter, zoom: 15, scrollwheel: false, draggable: true, mapTypeId: google.maps.MapTypeId.TERRAIN };
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
        var marker = new google.maps.Marker({ position: myCenter });
        marker.setMap(map);
    }
    );