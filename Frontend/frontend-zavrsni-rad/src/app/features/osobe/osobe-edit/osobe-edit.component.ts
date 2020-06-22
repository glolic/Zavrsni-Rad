import { Component, OnInit } from '@angular/core';
import { Drzava } from 'src/app/modeli/drzava-model';
import { Uloga } from 'src/app/modeli/uloga-model';
import { Osoba } from 'src/app/modeli/osoba-model';
import { DrzaveService } from '../../services/drzave-service';
import { SpoloviService } from '../../services/spolovi-service';
import { UlogeService } from '../../services/uloge-service';
import { OsobeService } from '../../services/osobe-service';
import { Spol } from 'src/app/modeli/spol-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DateAdapter } from '@angular/material/core';
import { formatDate } from '@angular/common';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-osobe-edit',
  templateUrl: './osobe-edit.component.html',
  styleUrls: ['./osobe-edit.component.scss']
})
export class OsobeEditComponent implements OnInit {

  name = new FormControl('');
  lastName = new FormControl('');
  dateOfBirth = new FormControl('');
  country = new FormControl('');
  oib = new FormControl('');
  gender = new FormControl('');
  role = new FormControl('');

  countryCollection: Drzava[];
  genderCollection: Spol[];
  roleCollection: Uloga[];

  osoba = new Osoba();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService,
    private spoloviService: SpoloviService,
    private ulogeService: UlogeService,
    private osobeService: OsobeService,
    private _adapter: DateAdapter<any>,
    private _snackBar: MatSnackBar
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.osobeService.get(params["id"]).subscribe(data => {
        this.osoba.id = data.id;
        this.osoba.ime = data.ime;
        this.osoba.prezime = data.prezime;
        this.osoba.datumRodenja = data.datumRodenja;
        this.osoba.drzavaRodenja = data.drzavaRodenja;
        this.osoba.oib = data.oib;
        this.osoba.spol = data.spol;
        this.osoba.uloga = data.uloga;
        this.setValues();
      })
    })
    this._adapter.setLocale('hr');
  }

  ngAfterContentInit() {
    this.drzaveService.getAllCountries().subscribe(
      (data) => {
        this.countryCollection = data;
      }
    );

    this.spoloviService.getAllGenders().subscribe(
      (data) => {
        this.genderCollection = data;
      }
    );

    this.ulogeService.getAllRoles().subscribe(
      (data) => {
        this.roleCollection = data;
      }
    );
  }

  private setValues() {
    this.name.setValue(this.osoba.ime);
    this.lastName.setValue(this.osoba.prezime);
    this.dateOfBirth.setValue(this.osoba.datumRodenja);
    this.country.setValue(this.osoba.drzavaRodenja);
    this.oib.setValue(this.osoba.oib);
    this.gender.setValue(this.osoba.spol);
    this.role.setValue(this.osoba.uloga);
  }

  gotoList() {
    this.router.navigate(['/osobe']);
  }

  onSubmit() {
    var formattedDate = new Date(this.dateOfBirth.value);
    var timeZoneDifference = (formattedDate.getTimezoneOffset() / 60) * -1; 
    formattedDate.setTime(formattedDate.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate.toISOString();
    
    if (this.name.valid) {
      let osoba = new Osoba(this.osoba.id, this.name.value, this.lastName.value, formattedDate, this.oib.value,
        this.gender.value, this.country.value, this.role.value);
      
      this.osobeService.update(osoba).subscribe(
        response => { 
          this._snackBar.open('Osoba uspješno ažurirana', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList() 
        }
      );
    }
    else {
      this.name.markAsTouched();
    }
  }

  displayFn1(drzava: Drzava): string {
    return drzava && drzava.nazivDrzave ? drzava.nazivDrzave : '';
  }

  displayFn2(spol: Spol): string {
    return spol && spol.naziv ? spol.naziv : '';
  }

  displayFn3(uloga: Uloga): string {
    return uloga && uloga.naziv ? uloga.naziv : '';
  }

}
