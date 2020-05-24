import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SpoloviGridComponent } from './features/spolovi/spolovi-grid/spolovi-grid.component';
import { SpoloviAddComponent } from './features/spolovi/spolovi-add/spolovi-add.component';
import { AgGridModule } from 'ag-grid-angular';
import { MatMenuModule, MatSidenavModule, MatIconModule, MatToolbarModule,
  MatListModule, MatSelectModule, MatTableModule, MatPaginator,
   MatPaginatorModule, MatSortModule, MatInputModule, MatButtonModule, MatCardModule, MatProgressSpinnerModule, MatDatepickerModule, MatCheckboxModule, MatAutocompleteModule, DateAdapter, MAT_DATE_FORMATS, MatSnackBarModule} from '@angular/material';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';
import { SpoloviService } from './features/services/spolovi-service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SpoloviEditComponent } from './features/spolovi/spolovi-edit/spolovi-edit.component';
import { DrzaveService } from './features/services/drzave-service';
import { DrzaveGridComponent } from './features/drzave/drzave-grid/drzave-grid.component';
import { DrzaveAddComponent } from './features/drzave/drzave-add/drzave-add.component';
import { DrzaveEditComponent } from './features/drzave/drzave-edit/drzave-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    SpoloviGridComponent,
    SpoloviAddComponent,
    SpoloviEditComponent,
    DrzaveGridComponent,
    DrzaveAddComponent,
    DrzaveEditComponent
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
    FormsModule
  ],
  providers: [SpoloviService, HttpClient, DrzaveService],
  bootstrap: [AppComponent]
})
export class AppModule { }
