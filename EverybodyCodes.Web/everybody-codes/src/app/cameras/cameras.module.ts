import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CamerasComponent } from './cameras.component';
import { CamerasRoutingModule } from './cameras-routing.module';
import { CameraService } from './services/camera.service';

@NgModule({
  declarations: [
    CamerasComponent
  ],
  imports: [
    CommonModule,
    CamerasRoutingModule
  ],
  providers: [CameraService],
})
export class CamerasModule { }
