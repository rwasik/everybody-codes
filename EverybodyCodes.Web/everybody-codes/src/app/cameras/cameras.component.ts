import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Camera } from './models/camera.model';
import { CameraService } from './services/camera.service';
import * as L from 'leaflet';
import { takeUntil } from 'rxjs/operators'

@Component({
  selector: 'app-cameras',
  templateUrl: './cameras.component.html',
  styleUrls: ['./cameras.component.css']
})
export class CamerasComponent implements OnInit, AfterViewInit, OnDestroy {

  divisibleByThree$: Observable<Camera[]> | undefined;
  divisibleByFive$: Observable<Camera[]> | undefined;
  divisibleByThreeAndFive$: Observable<Camera[]> | undefined;
  notDivisibleByThreeAndFive$: Observable<Camera[]> | undefined;

  map!: L.Map;

  destroy$ = new Subject();

  constructor(private cameraService: CameraService) { }

  ngOnInit(): void {
    this.divisibleByThree$ = this.cameraService.getDivisibleBy([3]);
    this.divisibleByFive$ = this.cameraService.getDivisibleBy([5]);
    this.divisibleByThreeAndFive$ = this.cameraService.getDivisibleBy([3, 5]);
    this.notDivisibleByThreeAndFive$ = this.cameraService.getDivisibleBy([3, 5], true);
  }

  ngAfterViewInit(): void {
    this.initMap();
    this.addMapTiles();
    this.renderMarkers();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  initMap(): void {
    this.map = L.map('map', {
      center: [52.0914, 5.1115],
      zoom: 15
    });
  }
  
  addMapTiles(): void {
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 3,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    tiles.addTo(this.map);
  }

  renderMarkers(): void {
    this.cameraService.getAll()
      .pipe(takeUntil(this.destroy$))
      .subscribe(
        cameras => {
          for (const c of cameras) {
            const marker = L.marker([c.latitude, c.longitude]);
            marker.bindTooltip(c.name).openTooltip();
            marker.addTo(this.map);
          }
        },
        err => {
          console.log('API error', err);
        });
  }
}
