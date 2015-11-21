
/*
  // This is called with the results from from FB.getLoginStatus().
  function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
      // Logged into your app and Facebook.
      testAPI();
    } else if (response.status === 'not_authorized') {
      // The person is logged into Facebook, but not your app.
      document.getElementById('status').innerHTML = 'Please log ' +
        'into this app.';
    } else {
      // The person is not logged into Facebook, so we're not sure if
      // they are logged into this app or not.
      document.getElementById('status').innerHTML = 'Please log ' +
        'into Facebook.';
    }
  }

  // This function is called when someone finishes with the Login
  // Button.  See the onlogin handler attached to it in the sample
  // code below.
  function checkLoginState() {
    FB.getLoginStatus(function(response) {
      statusChangeCallback(response);
    });
  }

  window.fbAsyncInit = function() {
  FB.init({
    appId      : '1489047034733274',
    cookie     : true,  // enable cookies to allow the server to access 
                        // the session
    xfbml      : true,  // parse social plugins on this page
    version    : 'v2.5' // use version 2.2
  });

  // Now that we've initialized the JavaScript SDK, we call 
  // FB.getLoginStatus().  This function gets the state of the
  // person visiting this page and can return one of three states to
  // the callback you provide.  They can be:
  //
  // 1. Logged into your app ('connected')
  // 2. Logged into Facebook, but not your app ('not_authorized')
  // 3. Not logged into Facebook and can't tell if they are logged into
  //    your app or not.
  //
  // These three cases are handled in the callback function.

  FB.getLoginStatus(function(response) {
    statusChangeCallback(response);
  });
  FB.Event.subscribe("auth.logout", function() {
         window.location = '/logout'
     });
  
  };

  // Load the SDK asynchronously
  (function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

  // Here we run a very simple test of the Graph API after login is
  // successful.  See statusChangeCallback() for when this call is made.
  function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function(response) {
      console.log('Successful login for: ' + response.name);
      document.getElementById('status').innerHTML =
        'Thanks for logging in, ' + response.name + '!';
    });
  }
  */
function Login(form) {
username = new Array("u1","u2","u3","u4","u5","u6","u7","u8","u9","u10");
password = new Array("p1","p2","p3","p4","p5","p6","p7","p8","p9","p10");
page = "admin" + ".html";
if (form.username.value == username[0] && form.password.value == password[0] || form.username.value == username[1] && form.password.value == password[1] || form.username.value == username[2] && form.password.value == password[2] || form.username.value == username[3] && form.password.value == password[3] || form.username.value == username[4] && form.password.value == password[4] || form.username.value == username[5] && form.password.value == password[5] || form.username.value == username[6] && form.password.value == password[6] || form.username.value == username[7] && form.password.value == password[7] || form.username.value == username[8] && form.password.value == password[8] || form.username.value == username[9] && form.password.value == password[9]) {
self.location.href = page;
}
else {
alert("Either the username or password you entered is incorrect.\nPlease try again.");
form.username.focus();
}
return true;
}
/*
function initialize() {
  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 12,
    center: {lat: 45.7777516, lng: 16.3250911},
    mapTypeControl: true,
    mapTypeControlOptions: {
        style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
        position: google.maps.ControlPosition.TOP_CENTER
    },
    zoomControl: true,
    zoomControlOptions: {
        position: google.maps.ControlPosition.LEFT_CENTER
    },
    scaleControl: true,
    streetViewControl: true,
    streetViewControlOptions: {
        position: google.maps.ControlPosition.LEFT_TOP
    }
  });
}

function initialize() {
        var mapCanvas = document.getElementById('map');
        var mapOptions = {
          center: new google.maps.LatLng(46.3313572, 16.3250911),
          zoom: 18,
          mapTypeId: google.maps.MapTypeId.HYBRID,
          scaleControl: false,
          scrollwheel: false,
          zoomControl: false
        }
        var map = new google.maps.Map(mapCanvas, mapOptions);

}
*/
var ikona;
function funkcijaDrvo(){
         ikona = 'https://maps.google.com/mapfiles/kml/shapes/parks.png';
        };
function funkcijaKuca(){
         ikona = 'https://maps.google.com/mapfiles/kml/shapes/homegardenbusiness.png';
        };
function funkcijaObjekt(){
         ikona = 'https://maps.google.com/mapfiles/kml/shapes/triangle.png';
        };
function funkcijaZastava(){
         ikona = 'https://maps.google.com/mapfiles/kml/shapes/flag.png';
        };
window.onload = function () {
    var mapOptions = {
        center: new google.maps.LatLng(46.3313572, 16.3250911),
        zoom: 18,
        mapTypeId: google.maps.MapTypeId.HYBRID,
        scaleControl: false,
        scrollwheel: false,
        zoomControl: true
    };
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
    /*
    var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';
    var icons = {
      parks: {
        icon: iconBase + 'parks.png'
      },
      kuca: {
        icon: iconBase + 'homegardenbusiness.png'
      },
      info: {
        icon: iconBase + 'info-i_maps.png'
      }
    };

    function addMarker(feature) {
      var marker = new google.maps.Marker({
        position: feature.position,
        icon: icons[feature.type].icon,
        map: map
      });
    }
 */
    

    //Attach click event handler to the map.
    google.maps.event.addListener(map, 'click', function (e) {

        //Determine the location where the user has clicked.
        var location = e.latLng;
        
        //Create a marker and placed it on the map.
        var marker = new google.maps.Marker({
            position: location,
            icon: ikona,
            map: map
        });
 
        //Attach click event handler to the marker.
        google.maps.event.addListener(marker, "click", function (e) {
            var infoWindow = new google.maps.InfoWindow({
                content: 'Latitude: ' + location.lat() + '<br />Longitude: ' + location.lng()
            });
            infoWindow.open(map, marker);
        });
    });
};