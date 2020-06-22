import { Component, OnInit } from '@angular/core';
import { Osoba } from 'src/app/modeli/osoba-model';
import { Pozicija } from 'src/app/modeli/pozicija-model';
import { Igrac } from 'src/app/modeli/igrac-model';
import { OsobeService } from '../../services/osobe-service';
import { PozicijeService } from '../../services/pozicije-service';
import { IgraciService } from '../../services/igraci-service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material';

@Component({
  selector: 'app-igraci-edit',
  templateUrl: './igraci-edit.component.html',
  styleUrls: ['./igraci-edit.component.scss']
})
export class IgraciEditComponent implements OnInit {

  person = new FormControl('');
  jerseyNumber = new FormControl('');
  position = new FormControl('');

  personCollection: Osoba[];
  positionCollection: Pozicija[];

  igrac = new Igrac();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private osobaService: OsobeService,
    private pozicijaService: PozicijeService,
    private igracService: IgraciService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.igracService.get(params["id"]).subscribe(data => {
        this.igrac.id = data.id;
        this.igrac.osoba = data.osoba;
        this.igrac.brojDresa = data.brojDresa;
        this.igrac.pozicija = data.pozicija;
        this.setValues();
      })
    })
  }

  ngAfterContentInit() {
    this.osobaService.getAllPersons().subscribe(
      (data) => {
        this.personCollection = data;
      }
    );

    this.pozicijaService.getAllPositions().subscribe(
      (data) => {
        this.positionCollection = data;
      }
    );
  }
  
  private setValues() {
    this.person.setValue(this.igrac.osoba);
    this.jerseyNumber.setValue(this.igrac.brojDresa);
    this.position.setValue(this.igrac.pozicija);
  }

  gotoList() {
    this.router.navigate(['/igraci']);
  }

  onSubmit() {
    if (this.person.valid) {
      let igrac = new Igrac(this.igrac.id, this.person.value, this.position.value, this.jerseyNumber.value);

      this.igracService.update(igrac).subscribe(
        response => { 
          this._snackBar.open('Igrač uspješno ažuriran', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList();
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

  displayFn2(pozicija: Pozicija): string {
    return pozicija && pozicija.naziv ? pozicija.naziv : '';
  }

}
