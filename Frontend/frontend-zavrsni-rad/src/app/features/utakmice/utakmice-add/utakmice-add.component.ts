import { Component, OnInit } from '@angular/core';
import { Utakmica } from 'src/app/modeli/utakmica-model';
import { FormControl } from '@angular/forms';
import { Momcad } from 'src/app/modeli/momcad-model';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { MomcadService } from '../../services/momcad-service';
import { NatjecanjaService } from '../../services/natjecanja-service';
import { UtakmiceService } from '../../services/utakmice-service';

@Component({
  selector: 'app-utakmice-add',
  templateUrl: './utakmice-add.component.html',
  styleUrls: ['./utakmice-add.component.scss']
})
export class UtakmiceAddComponent implements OnInit {

  dateOfGame = new FormControl('');
  team1 = new FormControl('');
  team2 = new FormControl('');
  score = new FormControl('');
  competition = new FormControl('');
  numOfVisitors = new FormControl('');

  teamCollection: Momcad[];
  competitionCollection: Natjecanje[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private momcadService: MomcadService,
    private natjecanjeService: NatjecanjaService,
    private utakmiceService: UtakmiceService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    
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

  gotoList() {
    this.router.navigate(['/utakmice']);
  }

  onSubmit(){
    var formattedDate = new Date(this.dateOfGame.value);
    var timeZoneDifference = (formattedDate.getTimezoneOffset() / 60) * -1; 
    formattedDate.setTime(formattedDate.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate.toISOString();
    
    if (this.team1.valid) {
      let utakmica = new Utakmica(null, this.team1.value, this.team2.value, formattedDate,
        this.score.value, this.competition.value, this.numOfVisitors.value);
      this.utakmiceService.add(utakmica).subscribe(
        response => {
          this._snackBar.open('Utakmica uspješno dodana', 'x', {
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
