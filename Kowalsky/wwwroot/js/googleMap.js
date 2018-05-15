function initializeMap() {
    var myLatlng = new window.google.maps.LatLng(47.511933, 19.034109899999976);
    var mapProp = {
        center: myLatlng,
        zoom: 18,
        scrollwheel: false,
        mapTypeId: window.google.maps.MapTypeId.ROADMAP
    };

    var map = new window.google.maps.Map(document.getElementById("googleMap"), mapProp);

    // ReSharper disable once UnusedLocals
    var marker = new window.google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Krizsma Autósiskola',
        animation: window.google.maps.Animation.DROP,
        icon: '/images/home/carmarker.png'
    });
}