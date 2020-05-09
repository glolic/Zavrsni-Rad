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
import { SpolService } from './features/services/spolovi-service';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    SpoloviGridComponent,
    SpoloviAddComponent
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
    HttpClientModule
  ],
  providers: [SpolService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
