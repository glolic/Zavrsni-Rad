import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SpoloviGridComponent } from './features/spolovi/spolovi-grid/spolovi-grid.component';
import { SpoloviAddComponent } from './features/spolovi/spolovi-add/spolovi-add.component';
import { AgGridModule } from 'ag-grid-angular';
import {
  MatMenuModule, MatSidenavModule, MatIconModule, MatToolbarModule,
  MatListModule, MatSelectModule, MatTableModule, MatPaginator,
  MatPaginatorModule, MatSortModule, MatInputModule, MatButtonModule, MatCardModule, MatProgressSpinnerModule, MatDatepickerModule, MatCheckboxModule, MatAutocompleteModule, DateAdapter, MAT_DATE_FORMATS, MatSnackBarModule, MatNativeDateModule, MAT_DATE_LOCALE
} from '@angular/material';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';
import { SpoloviService } from './features/services/spolovi-service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SpoloviEditComponent } from './features/spolovi/spolovi-edit/spolovi-edit.component';
import { DrzaveService } from './features/services/drzave-service';
import { DrzaveGridComponent } from './features/drzave/drzave-grid/drzave-grid.component';
import { DrzaveAddComponent } from './features/drzave/drzave-add/drzave-add.component';
import { DrzaveEditComponent } from './features/drzave/drzave-edit/drzave-edit.component';
import { LokacijeGridComponent } from './features/lokacije/lokacije-grid/lokacije-grid.component';
import { LokacijeAddComponent } from './features/lokacije/lokacije-add/lokacije-add.component';
import { LokacijeEditComponent } from './features/lokacije/lokacije-edit/lokacije-edit.component';
import { LokacijeService } from './features/services/lokacije-service';
import { UlogeGridComponent } from './features/uloge/uloge-grid/uloge-grid.component';
import { UlogeAddComponent } from './features/uloge/uloge-add/uloge-add.component';
import { UlogeEditComponent } from './features/uloge/uloge-edit/uloge-edit.component';
import { UlogeService } from './features/services/uloge-service';
import { PartneriGridComponent } from './features/partneri/partneri-grid/partneri-grid.component';
import { PartneriAddComponent } from './features/partneri/partneri-add/partneri-add.component';
import { PartneriEditComponent } from './features/partneri/partneri-edit/partneri-edit.component';
import { PartneriService } from './features/services/partner-service';
import { PlacanjaPartneraGridComponent } from './features/placanja-partnera/placanja-partnera-grid/placanja-partnera-grid.component';
import { PlacanjaPartneraAddComponent } from './features/placanja-partnera/placanja-partnera-add/placanja-partnera-add.component';
import { PlacanjaPartneraEditComponent } from './features/placanja-partnera/placanja-partnera-edit/placanja-partnera-edit.component';
import { PlacanjaPartneraService } from './features/services/placanja-partnera-service';
import { BooleanPipePipe } from './features/assets/boolean-pipe.pipe';
import { PozicijaGridComponent } from './features/pozicija/pozicija-grid/pozicija-grid.component';
import { PozicijaEditComponent } from './features/pozicija/pozicija-edit/pozicija-edit.component';
import { PozicijaAddComponent } from './features/pozicija/pozicija-add/pozicija-add.component';
import { PozicijeService } from './features/services/pozicije-service';
import { StadioniGridComponent } from './features/stadion/stadioni-grid/stadioni-grid.component';
import { StadioniEditComponent } from './features/stadion/stadioni-edit/stadioni-edit.component';
import { StadioniAddComponent } from './features/stadion/stadioni-add/stadioni-add.component';
import { StadioniService } from './features/services/stadioni-service';
import { NatjecanjaGridComponent } from './features/natjecanja/natjecanja-grid/natjecanja-grid.component';
import { NatjecanjaEditComponent } from './features/natjecanja/natjecanja-edit/natjecanja-edit.component';
import { NatjecanjaAddComponent } from './features/natjecanja/natjecanja-add/natjecanja-add.component';
import { NatjecanjaService } from './features/services/natjecanja-service';
import { KluboviGridComponent } from './features/klub/klubovi-grid/klubovi-grid.component';
import { KluboviAddComponent } from './features/klub/klubovi-add/klubovi-add.component';
import { KluboviEditComponent } from './features/klub/klubovi-edit/klubovi-edit.component';
import { KluboviService } from './features/services/klubovi-service';
import { SlicePipe, CommonModule, DatePipe, registerLocaleData } from '@angular/common';
import { MomcadService } from './features/services/momcad-service';
import { MomcadiGridComponent } from './features/momcadi/momcadi-grid/momcadi-grid.component';
import { MomcadiAddComponent } from './features/momcadi/momcadi-add/momcadi-add.component';
import { MomcadiEditComponent } from './features/momcadi/momcadi-edit/momcadi-edit.component';
import { OsobeService } from './features/services/osobe-service';
import { OsobeGridComponent } from './features/osobe/osobe-grid/osobe-grid.component';
import { OsobeAddComponent } from './features/osobe/osobe-add/osobe-add.component';
import { OsobeEditComponent } from './features/osobe/osobe-edit/osobe-edit.component';
import localeHR from '@angular/common/locales/hr';
import { IgraciGridComponent } from './features/igraci/igraci-grid/igraci-grid.component';
import { IgraciEditComponent } from './features/igraci/igraci-edit/igraci-edit.component';
import { IgraciAddComponent } from './features/igraci/igraci-add/igraci-add.component';
import { IgraciService } from './features/services/igraci-service';
registerLocaleData(localeHR);



@NgModule({
  declarations: [
    AppComponent,
    SpoloviGridComponent,
    SpoloviAddComponent,
    SpoloviEditComponent,
    DrzaveGridComponent,
    DrzaveAddComponent,
    DrzaveEditComponent,
    LokacijeGridComponent,
    LokacijeAddComponent,
    LokacijeEditComponent,
    UlogeGridComponent,
    UlogeAddComponent,
    UlogeEditComponent,
    PartneriGridComponent,
    PartneriAddComponent,
    PartneriEditComponent,
    PlacanjaPartneraGridComponent,
    PlacanjaPartneraAddComponent,
    PlacanjaPartneraEditComponent,
    BooleanPipePipe,
    PozicijaGridComponent,
    PozicijaEditComponent,
    PozicijaAddComponent,
    StadioniGridComponent,
    StadioniEditComponent,
    StadioniAddComponent,
    NatjecanjaGridComponent,
    NatjecanjaEditComponent,
    NatjecanjaAddComponent,
    KluboviGridComponent,
    KluboviAddComponent,
    KluboviEditComponent,
    MomcadiGridComponent,
    MomcadiAddComponent,
    MomcadiEditComponent,
    OsobeGridComponent,
    OsobeAddComponent,
    OsobeEditComponent,
    IgraciGridComponent,
    IgraciEditComponent,
    IgraciAddComponent
  ],
  imports: [
    BrowserModule,
    AgGridModule.withComponents([]),
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatButtonModule,
    MatMenuModule,
    MatSidenavModule,
    MatIconModule,
    MatToolbarModule,
    MatListModule,
    MatSelectModule,
    AppRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatSnackBarModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [SpoloviService,
  HttpClient,
  DrzaveService,
  LokacijeService,
  UlogeService,
  PartneriService,
  PlacanjaPartneraService,
  PozicijeService,
  StadioniService,
  NatjecanjaService,
  KluboviService,
  MomcadService,
  OsobeService,
  IgraciService,
  MatDatepickerModule,
  MatNativeDateModule,
  {provide: MAT_DATE_LOCALE, useValue: 'hr-HR'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
