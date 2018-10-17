/**
 * This is a simple JavaScript demostration of how to call MapBox API to load the maps.
 * The main reference to this is at 
 * I have set the default configuration to enable the geocoder and the navigation control.
 * https://www.mapbox.com/mapbox-gl-js/example/popup-on-click/
 * 
 * @author Jian Liew <jian.liew@monash.edu>
 * 
 * edited by Richard Aldrich Siem <rsie0001@student.monash.edu>
 */

const TOKEN = "pk.eyJ1IjoicnNpZW0iLCJhIjoiY2psNGg4anU5MTVoczNrbjNyenZwanBxeSJ9.DBTDs4C0kgfrM2huvyW8vA";
var locations = [];

// The first step is obtain all the latitude and longitude from the HTML
// The below is a simple jQuery selector
$(".coordinates").each(function () {
    var longitude = $(".longitude", this).text().trim();
    var latitude = $(".latitude", this).text().trim();
    var description = $(".description", this).text().trim();
    var hospID = $(".hospID", this).text().trim();

    // Create a point data structure to hold the values.
    var point = {
        "latitude": latitude,
        "longitude": longitude,
        "description": description,
        "hospID": hospID
    };

    // Push them all into an array.
    locations.push(point);
});

var data = [];

for (i = 0; i < locations.length; i++) {
    var feature = {
        "type": "Feature",
        "properties": {
            "description": locations[i].description,
            "hospID": locations[i].hospID,
            "icon": "circle-15"
        },
        "geometry": {
            "type": "Point",
            "coordinates": [locations[i].longitude, locations[i].latitude]
        }
    };
    data.push(feature)
}

mapboxgl.accessToken = TOKEN;

var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v10',
    zoom: 11,
    center: [locations[0].longitude, locations[0].latitude]
});

map.on('load', function () {
    // Add a source
    map.addSource("hospitals", {
        "type": "geojson",
        "data": {
            "type": "FeatureCollection",
            "features": data
        },
        cluster: true,
        clusterMaxZoom: 14, // Max zoom to cluster points on
        clusterRadius: 50 // Radius of each cluster when clustering points (defaults to 50)
    });

    map.addLayer({
        id: "clusters",
        type: "circle",
        source: "hospitals",
        filter: ["has", "point_count"],
        paint: {
            // Use step expressions (https://www.mapbox.com/mapbox-gl-js/style-spec/#expressions-step)
            // with three steps to implement three types of circles:
            //   * Blue, 15px circles when point count is less than 2
            //   * Yellow, 27px circles when point count is between 2 and 5
            //   * Pink, 40px circles when point count is greater than or equal to 5
            "circle-color": [
                "step",
                ["get", "point_count"],
                "#51bbd6",
                2,
                "#f1f075",
                5,
                "#f28cb1"
            ],
            "circle-radius": [
                "step",
                ["get", "point_count"],
                10,
                2,
                20,
                5,
                30
            ]
        }
    });

    // Add a cluster count
    map.addLayer({
        id: "cluster-count",
        type: "symbol",
        source: "hospitals",
        filter: ["has", "point_count"],
        layout: {
            "text-field": "{point_count_abbreviated}",
            "text-font": ["DIN Offc Pro Medium", "Arial Unicode MS Bold"],
            "text-size": 12
        }
    });

    // Add a layer showing the places.
    map.addLayer({
        "id": "unclustered_point",
        //"id": "places",
        //"type": "symbol",
        "type": "circle",
        "source": "hospitals",
        filter: ["!", ["has", "point_count"]],
        paint: {
            "circle-color": "#11b4da",
            "circle-radius": 10,
            "circle-stroke-width": 1,
            "circle-stroke-color": "#fff"
        }
        //"source": {
        //    "type": "geojson",
        //    "data": {
        //        "type": "FeatureCollection",
        //        "features": data
        //    }
        //},
        //"layout": {
        //    "icon-image": "{icon}",
        //    "icon-allow-overlap": true
        //}
    });

    map.addControl(new MapboxGeocoder({
        accessToken: mapboxgl.accessToken
    }));;

    map.addControl(new mapboxgl.NavigationControl());

    map.on('click', 'clusters', function (e) {
        var features = map.queryRenderedFeatures(e.point, { layers: ['clusters'] });
        var clusterId = features[0].properties.cluster_id;
        map.getSource('hospitals').getClusterExpansionZoom(clusterId, function (err, zoom) {
            if (err)
                return;

            map.easeTo({
                center: features[0].geometry.coordinates,
                zoom: zoom
            });
        });
    });

    map.on('mouseenter', 'clusters', function () {
        map.getCanvas().style.cursor = 'pointer';
    });

    map.on('mouseleave', 'clusters', function () {
        map.getCanvas().style.cursor = '';
    });

    // When a click event occurs on a feature in the places layer, open a popup at the
    // location of the feature, with description HTML from its properties.
    map.on('click', 'unclustered_point', function (e) {
        var coordinates = e.features[0].geometry.coordinates.slice();
        var description = "<strong>" + e.features[0].properties.description + "</strong>";
        var hospID = e.features[0].properties.hospID;

        var url = "/Hospitals/Details/" + hospID;
        var button = "<p></p><button id=\"reserve\" class=\"btn btn-default\">Make Reservation</button>"        

        // Ensure that if the map is zoomed out such that multiple
        // copies of the feature are visible, the popup appears
        // over the copy being pointed to.
        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }

        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML(description + button)
            .addTo(map);

        $("#reserve").click(function () {
            $(location).attr('href', url);
        });
    });

    // Change the cursor to a pointer when the mouse is over the places layer.
    map.on('mouseenter', 'unclustered_point', function () {
        map.getCanvas().style.cursor = 'pointer';
    });

    // Change it back to a pointer when it leaves.
    map.on('mouseleave', 'unclustered_point', function () {
        map.getCanvas().style.cursor = '';
    });
});