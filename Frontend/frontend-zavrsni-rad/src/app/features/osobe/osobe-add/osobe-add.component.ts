import { Component, OnInit } from '@angular/core';
import { Drzava } from 'src/app/modeli/drzava-model';
import { Spol } from 'src/app/modeli/spol-model';
import { Uloga } from 'src/app/modeli/uloga-model';
import { DrzaveService } from '../../services/drzave-service';
import { SpoloviService } from '../../services/spolovi-service';
import { UlogeService } from '../../services/uloge-service';
import { OsobeService } from '../../services/osobe-service';
import { Osoba } from 'src/app/modeli/osoba-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-osobe-add',
  templateUrl: './osobe-add.component.html',
  styleUrls: ['./osobe-add.component.scss']
})
export class OsobeAddComponent implements OnInit {

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

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService,
    private spoloviService: SpoloviService,
    private ulogeService: UlogeService,
    private osobeService: OsobeService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    
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

  gotoList() {
    this.router.navigate(['/osobe']);
  }

  onSubmit(){
    var formattedDate = new Date(this.dateOfBirth.value);
    var timeZoneDifference = (formattedDate.getTimezoneOffset() / 60) * -1; 
    formattedDate.setTime(formattedDate.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate.toISOString();
    
    if (this.name.valid) {
      let osoba = new Osoba(null, this.name.value, this.lastName.value, formattedDate, this.oib.value,
        this.gender.value, this.country.value, this.role.value);
      this.osobeService.add(osoba).subscribe(
        response => {
          this._snackBar.open('Osoba uspješno dodana', 'x', {
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
