import { Component, AfterViewInit, ViewChild, ElementRef } from'@angular/core';

const heatMapData = [
  {location: new google.maps.LatLng(37.782, -122.447), weight: 0.5},
  new google.maps.LatLng(37.782, -122.445),
  {location: new google.maps.LatLng(37.782, -122.443), weight: 2},
  {location: new google.maps.LatLng(37.782, -122.441), weight: 3},
  {location: new google.maps.LatLng(37.782, -122.439), weight: 2},
  new google.maps.LatLng(37.782, -122.437),
  {location: new google.maps.LatLng(37.782, -122.435), weight: 0.5},

  {location: new google.maps.LatLng(37.785, -122.447), weight: 3},
  {location: new google.maps.LatLng(37.785, -122.445), weight: 2},
  new google.maps.LatLng(37.785, -122.443),
  {location: new google.maps.LatLng(37.785, -122.441), weight: 0.5},
  new google.maps.LatLng(37.785, -122.439),
  {location: new google.maps.LatLng(37.785, -122.437), weight: 2},
  {location: new google.maps.LatLng(37.785, -122.435), weight: 3}
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements AfterViewInit {
  @ViewChild('mapContainer', { static: false }) gmap: ElementRef;
  map: google.maps.Map;

  heatmap : any;

  lat = 45.641026;
  lng = -73.499682;

  montreal = new google.maps.LatLng(this.lat, this.lng);

  mapOptions: google.maps.MapOptions = {
    center: this.montreal,
    zoom: 13
  };

  marker = new google.maps.Marker({
    position: this.montreal,
    map: this.map
  });

  ngAfterViewInit() {
    this.mapInitializer();
  }

  mapInitializer() {
    this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);

    this.heatmap  = new google.maps.visualization.HeatmapLayer({
      data: heatMapData
    });

    this.heatmap.setMap(this.map);
  
    this.marker.setMap(this.map);
  }
}
