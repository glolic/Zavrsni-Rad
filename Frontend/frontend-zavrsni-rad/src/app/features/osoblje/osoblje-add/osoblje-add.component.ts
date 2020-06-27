import { Component, OnInit } from '@angular/core';
import { Osoblje } from 'src/app/modeli/osoblje-model';
import { FormControl } from '@angular/forms';
import { Momcad } from 'src/app/modeli/momcad-model';
import { Osoba } from 'src/app/modeli/osoba-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { MomcadService } from '../../services/momcad-service';
import { OsobljeService } from '../../services/osoblje-service';
import { OsobeService } from '../../services/osobe-service';

@Component({
  selector: 'app-osoblje-add',
  templateUrl: './osoblje-add.component.html',
  styleUrls: ['./osoblje-add.component.scss']
})
export class OsobljeAddComponent implements OnInit {

  person = new FormControl('');
  dateOfLicense = new FormControl('');
  dateOfLicenseStart = new FormControl('');
  team = new FormControl('');

  teamCollection: Momcad[];
  personCollection: Osoba[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private momcadService: MomcadService,
    private osobljeService: OsobljeService,
    private osobeService: OsobeService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.osobeService.getAllPersons().subscribe(
      (data) => {
        this.personCollection = data;
      }
    );

    this.momcadService.getAllTeams().subscribe(
      (data) => {
        this.teamCollection = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/osoblje']);
  }

  onSubmit(){
    var formattedDate1 = new Date(this.dateOfLicenseStart.value);
    var timeZoneDifference = (formattedDate1.getTimezoneOffset() / 60) * -1; 
    formattedDate1.setTime(formattedDate1.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate1.toISOString();

    var formattedDate2 = new Date(this.dateOfLicense.value);
    var timeZoneDifference = (formattedDate2.getTimezoneOffset() / 60) * -1; 
    formattedDate2.setTime(formattedDate2.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate2.toISOString();
    
    if (this.person.valid) {
      let osoblje = new Osoblje(null,  this.person.value, this.team.value, formattedDate1, formattedDate2);
      this.osobljeService.add(osoblje).subscribe(
        response => {
          this._snackBar.open('Osoblje uspješno dodano', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList()
        }
      );
    }
    else {
      this.person.markAsTouched();
    }
  }

  displayFn1(osoba: Osoba): string {
    return osoba && osoba.ime + ' ' + osoba.prezime ? osoba.ime + ' ' + osoba.prezime : '';
  }

  displayFn2(momcad: Momcad): string {
    return momcad && momcad.naziv ? momcad.naziv : '';
  }

}
