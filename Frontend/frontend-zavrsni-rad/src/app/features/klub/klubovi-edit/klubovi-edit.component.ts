import { Component, OnInit } from '@angular/core';
import { Stadion } from 'src/app/modeli/stadion-model';
import { Klub } from 'src/app/modeli/klub-model';
import { KluboviService } from '../../services/klubovi-service';
import { StadioniService } from '../../services/stadioni-service';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LokacijeService } from '../../services/lokacije-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-klubovi-edit',
  templateUrl: './klubovi-edit.component.html',
  styleUrls: ['./klubovi-edit.component.scss']
})
export class KluboviEditComponent implements OnInit {

  name = new FormControl('');
  establishmentYear = new FormControl('');
  clubResidence = new FormControl('');
  stadium = new FormControl('');

  lokacijaCollection: Lokacija[];
  stadiumCollection: Stadion[];

  klub = new Klub();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private stadionService: StadioniService,
    private lokacijaService: LokacijeService,
    private klubService: KluboviService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.klubService.get(params["id"]).subscribe(data => {
        this.klub.id = data.id;
        this.klub.naziv = data.naziv;
        this.klub.godinaOsnivanja = data.godinaOsnivanja;
        this.klub.sjedisteKluba = data.sjedisteKluba;
        this.klub.stadion = data.stadion;
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

    this.stadionService.getAllStadiums().subscribe(
      (data) => {
        this.stadiumCollection = data;
      }
    );
  }
  
  private setValues() {
    this.name.setValue(this.klub.naziv);
    this.establishmentYear.setValue(this.klub.godinaOsnivanja);
    this.stadium.setValue(this.klub.stadion);
    this.clubResidence.setValue(this.klub.sjedisteKluba);
  }

  gotoList() {
    this.router.navigate(['/klubovi']);
  }

  onSubmit() {
    if (this.name.valid) {
      let klub = new Klub(this.klub.id, this.name.value, this.establishmentYear.value, this.clubResidence.value, this.stadium.value);

      this.klubService.update(klub).subscribe(
        response => { 
          this.gotoList()
          this._snackBar.open('Klub uspješno ažuriran', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
         }
      );
    }
    else {
      this.name.markAsTouched();
    }
  }

  displayFn1(lokacija: Lokacija): string {
    return lokacija && lokacija.adresa ? lokacija.adresa : '';
  }

  displayFn2(stadion: Stadion): string {
    return stadion && stadion.naziv ? stadion.naziv : '';
  }
}
