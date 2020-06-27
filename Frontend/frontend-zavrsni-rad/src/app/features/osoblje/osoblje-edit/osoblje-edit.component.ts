import { Component, OnInit } from '@angular/core';
import { Momcad } from 'src/app/modeli/momcad-model';
import { Osoba } from 'src/app/modeli/osoba-model';
import { Osoblje } from 'src/app/modeli/osoblje-model';
import { MomcadService } from '../../services/momcad-service';
import { OsobljeService } from '../../services/osoblje-service';
import { FormControl } from '@angular/forms';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, DateAdapter, MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { OsobeService } from '../../services/osobe-service';

@Component({
  selector: 'app-osoblje-edit',
  templateUrl: './osoblje-edit.component.html',
  styleUrls: ['./osoblje-edit.component.scss']
})
export class OsobljeEditComponent implements OnInit {

  person = new FormControl('');
  dateOfLicense = new FormControl('');
  hasLicense = new FormControl('');
  team = new FormControl('');

  teamCollection: Momcad[];
  personCollection: Osoba[];

  osoblje = new Osoblje();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  public isReadOnly: boolean;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private momcadService: MomcadService,
    private osobljeService: OsobljeService,
    private osobeService: OsobeService,
    private _adapter: DateAdapter<any>,
    private _snackBar: MatSnackBar
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.osobljeService.get(params["id"]).subscribe(data => {
        this.osoblje.id = data.id;
        this.osoblje.osoba = data.osoba;
        this.osoblje.momcad = data.momcad;
        this.osoblje.datumIstekaDozvole = data.datumIstekaDozvole;
        this.osoblje.dozvolaZaRad = data.dozvolaZaRad;
        this.setValues();
      })
    })
    this._adapter.setLocale('hr');
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

  private setValues() {
    this.person.setValue(this.osoblje.osoba);
    this.team.setValue(this.osoblje.momcad);
    this.dateOfLicense.setValue(this.osoblje.datumIstekaDozvole);
    this.hasLicense.setValue(this.osoblje.dozvolaZaRad);
  }

  gotoList() {
    this.router.navigate(['/osoblje']);
  }

  onSubmit() {
    var formattedDate = new Date(this.dateOfLicense.value);
    var timeZoneDifference = (formattedDate.getTimezoneOffset() / 60) * -1; 
    formattedDate.setTime(formattedDate.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate.toISOString();
    
    if (this.person.valid) {
      let osoblje = new Osoblje(this.osoblje.id, this.person.value, this.team.value, this.hasLicense.value, formattedDate);
      
      this.osobljeService.update(osoblje).subscribe(
        response => { 
          this._snackBar.open('Osoblje uspješno ažurirano', 'x', {
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

  public enableDate($event)
  {
    console.log($event);
  }

  displayFn1(osoba: Osoba): string {
    return osoba && osoba.ime + ' ' + osoba.prezime ? osoba.ime + ' ' + osoba.prezime : '';
  }

  displayFn2(momcad: Momcad): string {
    return momcad && momcad.naziv ? momcad.naziv : '';
  }

}
