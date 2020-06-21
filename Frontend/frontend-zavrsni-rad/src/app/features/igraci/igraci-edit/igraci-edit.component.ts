import { Component, OnInit } from '@angular/core';
import { Osoba } from 'src/app/modeli/osoba-model';
import { Pozicija } from 'src/app/modeli/pozicija-model';
import { Igrac } from 'src/app/modeli/igrac-model';
import { ImePrezime } from 'src/app/modeli/ime-prezime-model';
import { OsobeService } from '../../services/osobe-service';
import { PozicijeService } from '../../services/pozicije-service';
import { IgraciService } from '../../services/igraci-service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ImePrezimeService } from '../../services/ime-prezime.service';

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
  nameLastNameCollection: ImePrezime[];

  igrac = new Igrac();

  constructor(private route: ActivatedRoute,
    private router: Router,
    private osobaService: OsobeService,
    private pozicijaService: PozicijeService,
    private igracService: IgraciService,
    private imePrezimeService: ImePrezimeService) { }

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

    this.imePrezimeService.getAllNamesAndLastNames().subscribe(
      (data)=> {
        this.nameLastNameCollection = data;
      }
    )
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
        response => { this.gotoList() }
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
