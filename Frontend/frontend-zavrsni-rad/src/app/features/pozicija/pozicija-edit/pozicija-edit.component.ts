import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Pozicija } from 'src/app/modeli/pozicija-model';
import { ActivatedRoute, Router } from '@angular/router';
import { PozicijeService } from '../../services/pozicije-service';

@Component({
  selector: 'app-pozicija-edit',
  templateUrl: './pozicija-edit.component.html',
  styleUrls: ['./pozicija-edit.component.scss']
})
export class PozicijaEditComponent implements OnInit {

  name = new FormControl('');
  pozicija = new Pozicija();
  constructor(private route: ActivatedRoute,
    private router: Router,
    private pozicijaService: PozicijeService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.pozicijaService.get(params["id"]).subscribe(data => {
        this.pozicija.id = data.id;
        this.pozicija.naziv = data.naziv;
        this.setValues();
      })
    })
  }
  private setValues() {
    this.name.setValue(this.pozicija.naziv);
  }
  gotoList() {
    this.router.navigate(['/pozicije']);
  }
  onSubmit() {
    if (this.name.valid) {
      let pozicija = new Pozicija(this.pozicija.id, this.name.value);

      this.pozicijaService.update(pozicija).subscribe(
        response => { this.gotoList() }
      );
    }
    else {
      this.name.markAsTouched();
    }

  }

}
