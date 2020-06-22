import { Component, OnInit } from '@angular/core';
import { Klub } from 'src/app/modeli/klub-model';
import { FormControl } from '@angular/forms';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { Stadion } from 'src/app/modeli/stadion-model';
import { ActivatedRoute, Router } from '@angular/router';
import { StadioniService } from '../../services/stadioni-service';
import { LokacijeService } from '../../services/lokacije-service';
import { KluboviService } from '../../services/klubovi-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-klubovi-add',
  templateUrl: './klubovi-add.component.html',
  styleUrls: ['./klubovi-add.component.scss']
})
export class KluboviAddComponent implements OnInit {

  name = new FormControl('');
  establishmentYear = new FormControl('');
  stadium = new FormControl('');
  clubResidence = new FormControl('');

  lokacijaCollection: Lokacija[];
  stadiumCollection: Stadion[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private stadionService: StadioniService,
    private lokacijaService: LokacijeService,
    private klubService: KluboviService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    
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

  gotoList() {
    this.router.navigate(['/klubovi']);
  }

  onSubmit(){
    if (this.name.valid) {
      let klub = new Klub(null, this.name.value, this.establishmentYear.value, this.clubResidence.value, this.stadium.value);
      this.klubService.add(klub).subscribe(
        response => {
          this._snackBar.open('Klub uspješno dodan', 'x', {
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

  displayFn1(lokacija: Lokacija): string {
    return lokacija && lokacija.adresa ? lokacija.adresa : '';
  }

  displayFn2(stadion: Stadion): string {
    return stadion && stadion.naziv ? stadion.naziv : '';
  }

}
