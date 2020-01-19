import { Component, AfterViewInit, ViewChild, ElementRef, OnInit } from'@angular/core';
import { CurrentDataService } from '../services/current-data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements AfterViewInit, OnInit{
  @ViewChild('mapContainer', { static: false }) gmap: ElementRef;
  map: google.maps.Map;

  heatMapData: any[] = [];
  heatmap : any;

  lat = 45.641026;
  lng = -73.499682;

  montreal = new google.maps.LatLng(this.lat, this.lng);

  mapOptions: google.maps.MapOptions = {
    center: this.montreal,
    zoom: 13
  };

  constructor(private currentDataService: CurrentDataService) {

  }
  ngOnInit() {
    this.currentDataService.fetchData()
      .then(x => {
        x.stations.forEach(station => {
          this.heatMapData.push(
            { location: new google.maps.LatLng(station.latitude, station.longitude), weight: station.qualite }
          )
        })
      })
      .catch(e => console.log(e));
  }

  ngAfterViewInit() {
    this.mapInitializer();
  }

  mapInitializer() {
    this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);

    this.heatmap  = new google.maps.visualization.HeatmapLayer({
      data: this.heatMapData
    });

    this.heatmap.setMap(this.map);
  }
}
