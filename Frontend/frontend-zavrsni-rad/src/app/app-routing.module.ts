import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SpoloviGridComponent } from './features/spolovi/spolovi-grid/spolovi-grid.component';
import { SpoloviAddComponent } from './features/spolovi/spolovi-add/spolovi-add.component';
import { SpoloviEditComponent } from './features/spolovi/spolovi-edit/spolovi-edit.component';


const routes: Routes = [
  { path: 'spolovi', component: SpoloviGridComponent },
  { path: 'spolovi-edit/:id', component: SpoloviEditComponent },
  { path: 'spolovi-add', component: SpoloviAddComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
