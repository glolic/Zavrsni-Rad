import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SpoloviGridComponent } from './features/spolovi/spolovi-grid/spolovi-grid.component';
import { SpoloviAddComponent } from './features/spolovi/spolovi-add/spolovi-add.component';
import { SpoloviEditComponent } from './features/spolovi/spolovi-edit/spolovi-edit.component';
import { DrzaveGridComponent } from './features/drzave/drzave-grid/drzave-grid.component';
import { DrzaveEditComponent } from './features/drzave/drzave-edit/drzave-edit.component';
import { DrzaveAddComponent } from './features/drzave/drzave-add/drzave-add.component';
import { LokacijeGridComponent } from './features/lokacije/lokacije-grid/lokacije-grid.component';
import { LokacijeEditComponent } from './features/lokacije/lokacije-edit/lokacije-edit.component';
import { LokacijeAddComponent } from './features/lokacije/lokacije-add/lokacije-add.component';
import { UlogeGridComponent } from './features/uloge/uloge-grid/uloge-grid.component';
import { UlogeEditComponent } from './features/uloge/uloge-edit/uloge-edit.component';
import { UlogeAddComponent } from './features/uloge/uloge-add/uloge-add.component';


const routes: Routes = [
  { path: 'spolovi', component: SpoloviGridComponent },
  { path: 'spolovi-edit/:id', component: SpoloviEditComponent },
  { path: 'spolovi-add', component: SpoloviAddComponent },
  { path: 'drzave', component: DrzaveGridComponent },
  { path: 'drzave-edit/:id', component: DrzaveEditComponent },
  { path: 'drzave-add', component: DrzaveAddComponent },
  { path: 'lokacije', component: LokacijeGridComponent },
  { path: 'lokacije-edit/:id', component: LokacijeEditComponent },
  { path: 'lokacije-add', component: LokacijeAddComponent },
  { path: 'uloge', component: UlogeGridComponent },
  { path: 'uloge-edit/:id', component: UlogeEditComponent },
  { path: 'uloge-add', component: UlogeAddComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
