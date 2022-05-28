import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'cameras',
    loadChildren: () => import('./cameras/cameras.module').then(m => m.CamerasModule)
  },
  {
    path: '',
    redirectTo: '/cameras',
    pathMatch: 'full'
  },
  {
    path: '**', 
    redirectTo: '/cameras'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
