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
import { PartneriGridComponent } from './features/partneri/partneri-grid/partneri-grid.component';
import { PartneriEditComponent } from './features/partneri/partneri-edit/partneri-edit.component';
import { PartneriAddComponent } from './features/partneri/partneri-add/partneri-add.component';
import { PlacanjaPartneraGridComponent } from './features/placanja-partnera/placanja-partnera-grid/placanja-partnera-grid.component';
import { PlacanjaPartneraEditComponent } from './features/placanja-partnera/placanja-partnera-edit/placanja-partnera-edit.component';
import { PlacanjaPartneraAddComponent } from './features/placanja-partnera/placanja-partnera-add/placanja-partnera-add.component';
import { PozicijaGridComponent } from './features/pozicija/pozicija-grid/pozicija-grid.component';
import { PozicijaEditComponent } from './features/pozicija/pozicija-edit/pozicija-edit.component';
import { PozicijaAddComponent } from './features/pozicija/pozicija-add/pozicija-add.component';
import { StadioniGridComponent } from './features/stadion/stadioni-grid/stadioni-grid.component';
import { StadioniEditComponent } from './features/stadion/stadioni-edit/stadioni-edit.component';
import { StadioniAddComponent } from './features/stadion/stadioni-add/stadioni-add.component';
import { NatjecanjaGridComponent } from './features/natjecanja/natjecanja-grid/natjecanja-grid.component';
import { NatjecanjaEditComponent } from './features/natjecanja/natjecanja-edit/natjecanja-edit.component';
import { NatjecanjaAddComponent } from './features/natjecanja/natjecanja-add/natjecanja-add.component';
import { KluboviGridComponent } from './features/klub/klubovi-grid/klubovi-grid.component';
import { KluboviEditComponent } from './features/klub/klubovi-edit/klubovi-edit.component';
import { KluboviAddComponent } from './features/klub/klubovi-add/klubovi-add.component';
import { MomcadiGridComponent } from './features/momcadi/momcadi-grid/momcadi-grid.component';
import { MomcadiEditComponent } from './features/momcadi/momcadi-edit/momcadi-edit.component';
import { MomcadiAddComponent } from './features/momcadi/momcadi-add/momcadi-add.component';
import { OsobeGridComponent } from './features/osobe/osobe-grid/osobe-grid.component';
import { OsobeEditComponent } from './features/osobe/osobe-edit/osobe-edit.component';
import { OsobeAddComponent } from './features/osobe/osobe-add/osobe-add.component';
import { IgraciGridComponent } from './features/igraci/igraci-grid/igraci-grid.component';
import { IgraciEditComponent } from './features/igraci/igraci-edit/igraci-edit.component';
import { IgraciAddComponent } from './features/igraci/igraci-add/igraci-add.component';
import { UtakmiceGridComponent } from './features/utakmice/utakmice-grid/utakmice-grid.component';
import { UtakmiceEditComponent } from './features/utakmice/utakmice-edit/utakmice-edit.component';
import { UtakmiceAddComponent } from './features/utakmice/utakmice-add/utakmice-add.component';


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
  { path: 'partneri', component: PartneriGridComponent },
  { path: 'partneri-edit/:id', component: PartneriEditComponent },
  { path: 'partneri-add', component: PartneriAddComponent },
  { path: 'placanja-partnera', component: PlacanjaPartneraGridComponent },
  { path: 'placanja-partnera-edit/:id', component: PlacanjaPartneraEditComponent },
  { path: 'placanja-partnera-add', component: PlacanjaPartneraAddComponent },
  { path: 'pozicije', component: PozicijaGridComponent },
  { path: 'pozicije-edit/:id', component: PozicijaEditComponent },
  { path: 'pozicije-add', component: PozicijaAddComponent },
  { path: 'stadioni', component: StadioniGridComponent },
  { path: 'stadioni-edit/:id', component: StadioniEditComponent },
  { path: 'stadioni-add', component: StadioniAddComponent },
  { path: 'natjecanja', component: NatjecanjaGridComponent },
  { path: 'natjecanja-edit/:id', component: NatjecanjaEditComponent },
  { path: 'natjecanja-add', component: NatjecanjaAddComponent },
  { path: 'klubovi', component: KluboviGridComponent },
  { path: 'klubovi-edit/:id', component: KluboviEditComponent },
  { path: 'klubovi-add', component: KluboviAddComponent },
  { path: 'momcadi', component: MomcadiGridComponent },
  { path: 'momcadi-edit/:id', component: MomcadiEditComponent },
  { path: 'momcadi-add', component: MomcadiAddComponent },
  { path: 'osobe', component: OsobeGridComponent },
  { path: 'osobe-edit/:id', component: OsobeEditComponent },
  { path: 'osobe-add', component: OsobeAddComponent },
  { path: 'igraci', component: IgraciGridComponent },
  { path: 'igraci-edit/:id', component: IgraciEditComponent },
  { path: 'igraci-add', component: IgraciAddComponent },
  { path: 'utakmice', component: UtakmiceGridComponent },
  { path: 'utakmice-edit/:id', component: UtakmiceEditComponent },
  { path: 'utakmice-add', component: UtakmiceAddComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
