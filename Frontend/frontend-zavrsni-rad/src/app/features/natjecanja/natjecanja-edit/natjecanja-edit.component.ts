import { Component, OnInit } from '@angular/core';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { NatjecanjaService } from '../../services/natjecanja-service';
import { FormControl } from '@angular/forms';
import { Drzava } from 'src/app/modeli/drzava-model';
import { ActivatedRoute, Router } from '@angular/router';
import { DrzaveService } from '../../services/drzave-service';

@Component({
  selector: 'app-natjecanja-edit',
  templateUrl: './natjecanja-edit.component.html',
  styleUrls: ['./natjecanja-edit.component.scss']
})
export class NatjecanjaEditComponent implements OnInit {

  name = new FormControl('');
  country = new FormControl('');

  drzaveCollection: Drzava[];

  natjecanje = new Natjecanje();
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private natjecanjeService: NatjecanjaService,
    private drzaveService: DrzaveService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.natjecanjeService.get(params["id"]).subscribe(data => {
        this.natjecanje.id = data.id;
        this.natjecanje.imeNatjecanja = data.imeNatjecanja;
        this.natjecanje.drzava = data.drzava;
        this.setValues();
      })
    })
  }
  
  ngAfterContentInit() {
    this.drzaveService.getAllCountries().subscribe(
      (data) => {
        this.drzaveCollection = data;
      }
    );
  }
  
  private setValues() {
    this.name.setValue(this.natjecanje.imeNatjecanja);
    this.country.setValue(this.natjecanje.drzava);
  }

  gotoList() {
    this.router.navigate(['/natjecanja']);
  }

  onSubmit() {
    if (this.name.valid) {
      let natjecanje = new Natjecanje(this.natjecanje.id, this.name.value, this.country.value);

      this.natjecanjeService.update(natjecanje).subscribe(
        response => { this.gotoList() }
      );
    }
    else {
      this.name.markAsTouched();
    }
  }

  displayFn(drzava: Drzava): string {
    return drzava && drzava.nazivDrzave ? drzava.nazivDrzave : '';
  }

}
