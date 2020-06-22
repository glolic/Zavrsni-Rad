import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { Stadion } from 'src/app/modeli/stadion-model';
import { StadioniService } from '../../services/stadioni-service';
import { ActivatedRoute, Router } from '@angular/router';
import { LokacijeService } from '../../services/lokacije-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-stadioni-edit',
  templateUrl: './stadioni-edit.component.html',
  styleUrls: ['./stadioni-edit.component.scss']
})
export class StadioniEditComponent implements OnInit {

  name = new FormControl('');
  capacity = new FormControl('');
  location = new FormControl('');

  lokacijaCollection: Lokacija[];

  stadion = new Stadion();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private lokacijaService: LokacijeService,
    private stadionService: StadioniService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.stadionService.get(params["id"]).subscribe(data => {
        this.stadion.id = data.id;
        this.stadion.naziv = data.naziv;
        this.stadion.kapacitet = data.kapacitet;
        this.stadion.lokacija = data.lokacija;
        this.setValues();
      })
    })
  }
  
  ngAfterContentInit() {
    this.lokacijaService.getAllLocations().subscribe(
      (data) => {
        this.lokacijaCollection = data;
      }
    );
  }
  
  private setValues() {
    this.name.setValue(this.stadion.naziv);
    this.capacity.setValue(this.stadion.kapacitet);
    this.location.setValue(this.stadion.lokacija);
  }

  gotoList() {
    this.router.navigate(['/stadioni']);
  }

  onSubmit() {
    if (this.name.valid) {
      let stadion = new Stadion(this.stadion.id, this.name.value, this.capacity.value, this.location.value);

      this.stadionService.update(stadion).subscribe(
        response => { 
          this._snackBar.open('Stadion uspješno ažuriran', 'x', {
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

  displayFn(lokacija: Lokacija): string {
    return lokacija && lokacija.adresa ? lokacija.adresa : '';
  }

}
