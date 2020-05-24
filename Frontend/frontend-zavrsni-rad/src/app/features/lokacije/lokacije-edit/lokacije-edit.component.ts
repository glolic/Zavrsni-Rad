import { Component, OnInit } from '@angular/core';
import { LokacijeService } from '../../services/lokacije-service';
import { FormControl } from '@angular/forms';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { ActivatedRoute, Router } from '@angular/router';
import { Drzava } from 'src/app/modeli/drzava-model';

@Component({
  selector: 'app-lokacije-edit',
  templateUrl: './lokacije-edit.component.html',
  styleUrls: ['./lokacije-edit.component.scss']
})
export class LokacijeEditComponent implements OnInit {

  address = new FormControl('');
  country = new FormControl('');

  lokacija = new Lokacija();
  constructor(private route: ActivatedRoute,
    private router: Router,
    private lokacijaService: LokacijeService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.lokacijaService.get(params["id"]).subscribe(data => {
        this.lokacija.id = data.id;
        this.lokacija.adresa = data.adresa;
        this.lokacija.drzava = data.drzava;
        this.setValues();
      })
    })
  }
  private setValues() {
    this.address.setValue(this.lokacija.adresa);
    this.country.setValue(this.lokacija.drzava);
  }
  gotoList() {
    this.router.navigate(['/lokacije']);
  }
  onSubmit() {
    if (this.address.valid) {
      let lokacija = new Lokacija(this.lokacija.id, this.address.value, this.country.value);

      this.lokacijaService.update(lokacija).subscribe(
        response => { this.gotoList() }
      );
    }
    else {
      this.address.markAsTouched();
    }
  }

  displayFn(drzava: Drzava): string {
    return drzava && drzava.nazivDrzave ? drzava.nazivDrzave : '';
  }
}
