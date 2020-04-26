import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SpoloviGridComponent } from './features/spolovi/spolovi-grid/spolovi-grid.component';


const routes: Routes = [
  { path: 'spolovi', component: SpoloviGridComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
