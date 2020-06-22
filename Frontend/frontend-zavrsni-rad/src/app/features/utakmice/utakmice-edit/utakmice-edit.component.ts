import { Component, OnInit } from '@angular/core';
import { Momcad } from 'src/app/modeli/momcad-model';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { Utakmica } from 'src/app/modeli/utakmica-model';
import { MomcadService } from '../../services/momcad-service';
import { NatjecanjaService } from '../../services/natjecanja-service';
import { UtakmiceService } from '../../services/utakmice-service';
import { FormControl } from '@angular/forms';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, DateAdapter, MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-utakmice-edit',
  templateUrl: './utakmice-edit.component.html',
  styleUrls: ['./utakmice-edit.component.scss']
})
export class UtakmiceEditComponent implements OnInit {

  dateOfGame = new FormControl('');
  team1 = new FormControl('');
  team2 = new FormControl('');
  score = new FormControl('');
  competition = new FormControl('');
  numOfVisitors = new FormControl('');

  teamCollection: Momcad[];
  competitionCollection: Natjecanje[];

  utakmica = new Utakmica();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private momcadService: MomcadService,
    private natjecanjeService: NatjecanjaService,
    private utakmiceService: UtakmiceService,
    private _adapter: DateAdapter<any>,
    private _snackBar: MatSnackBar
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.utakmiceService.get(params["id"]).subscribe(data => {
        this.utakmica.id = data.id;
        this.utakmica.datumUtakmice = data.datumUtakmice;
        this.utakmica.momcad1 = data.momcad1;
        this.utakmica.momcad2 = data.momcad2;
        this.utakmica.natjecanje = data.natjecanje;
        this.utakmica.brojPosjetitelja = data.brojPosjetitelja;
        this.utakmica.rezultat = data.rezultat;
        this.setValues();
      })
    })
    this._adapter.setLocale('hr');
  }

  ngAfterContentInit() {
    this.momcadService.getAllTeams().subscribe(
      (data) => {
        this.teamCollection = data;
      }
    );

    this.natjecanjeService.getAllCompetitions().subscribe(
      (data) => {
        this.competitionCollection = data;
      }
    );
  }

  private setValues() {
    this.dateOfGame.setValue(this.utakmica.datumUtakmice);
    this.team1.setValue(this.utakmica.momcad1);
    this.team2.setValue(this.utakmica.momcad2);
    this.score.setValue(this.utakmica.rezultat);
    this.numOfVisitors.setValue(this.utakmica.brojPosjetitelja);
    this.competition.setValue(this.utakmica.natjecanje);
  }

  gotoList() {
    this.router.navigate(['/utakmice']);
  }

  onSubmit() {
    var formattedDate = new Date(this.dateOfGame.value);
    var timeZoneDifference = (formattedDate.getTimezoneOffset() / 60) * -1; 
    formattedDate.setTime(formattedDate.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate.toISOString();
    
    if (this.team1.valid) {
      let utakmica = new Utakmica(this.utakmica.id, this.team1.value, this.team2.value, formattedDate,
        this.score.value, this.competition.value, this.numOfVisitors.value);
      
      this.utakmiceService.update(utakmica).subscribe(
        response => { 
          this._snackBar.open('Utakmica uspješno ažurirana', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList() 
        }
      );
    }
    else {
      this.team1.markAsTouched();
    }
  }

  displayFn1(momcad1: Momcad): string {
    return momcad1 && momcad1.naziv ? momcad1.naziv : '';
  }

  displayFn2(momcad2: Momcad): string {
    return momcad2 && momcad2.naziv ? momcad2.naziv : '';
  }

  displayFn3(natjecanje: Natjecanje): string {
    return natjecanje && natjecanje.imeNatjecanja ? natjecanje.imeNatjecanja : '';
  }
}
