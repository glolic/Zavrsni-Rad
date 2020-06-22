import { Component, OnInit } from '@angular/core';
import { Igrac } from 'src/app/modeli/igrac-model';
import { FormControl } from '@angular/forms';
import { Osoba } from 'src/app/modeli/osoba-model';
import { Pozicija } from 'src/app/modeli/pozicija-model';
import { ActivatedRoute, Router } from '@angular/router';
import { OsobeService } from '../../services/osobe-service';
import { PozicijeService } from '../../services/pozicije-service';
import { IgraciService } from '../../services/igraci-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-igraci-add',
  templateUrl: './igraci-add.component.html',
  styleUrls: ['./igraci-add.component.scss']
})
export class IgraciAddComponent implements OnInit {

  person = new FormControl('');
  jerseyNumber = new FormControl('');
  position = new FormControl('');

  personCollection: Osoba[];
  positionCollection: Pozicija[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private osobaService: OsobeService,
    private pozicijaService: PozicijeService,
    private igracService: IgraciService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    
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

  gotoList() {
    this.router.navigate(['/igraci']);
  }

  onSubmit(){
    if (this.person.valid) {
      let igrac = new Igrac(null, this.person.value, this.position.value, this.jerseyNumber.value);
      this.igracService.add(igrac).subscribe(
        response => {
          this._snackBar.open('Igrač uspješno ažuriran', 'x', {
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

  displayFn2(pozicija: Pozicija): string {
    return pozicija && pozicija.naziv ? pozicija.naziv : '';
  }

}
