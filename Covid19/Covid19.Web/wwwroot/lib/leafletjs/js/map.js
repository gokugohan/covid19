
/* Basemap Layers */
let baseMap = new L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>',
    maxZoom: 25,
    minZoom: 1,
    id: 'mapbox.dark',
    accessToken: 'pk.eyJ1IjoiaG1lbmV6ZXMiLCJhIjoiY2prYzdmcWozMDFmNzNwbzZkMWptZ3ptNSJ9.e-iIExHcob-nAATM_CFAEQ'
});

var southWest = L.latLng(-44.46515101351963, -62.05078125000001), northEast = L.latLng(66.79190947341796, 62.05078125000001);
var mapBoundaries = L.latLngBounds(southWest, northEast);



map = L.map("map", {
    // maxBounds:mapBoundaries,
    zoom: 2,
    center: [0, 0],
    zoomControl: false,
    attributionControl: false
});

baseMap.addTo(map);