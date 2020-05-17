import { Component, OnInit } from '@angular/core';
import { Spol } from 'src/app/modeli/spol-model';
import { SpoloviService } from '../../services/spolovi-service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-spolovi-edit',
  templateUrl: './spolovi-edit.component.html',
  styleUrls: ['./spolovi-edit.component.scss']
})
export class SpoloviEditComponent implements OnInit {

  name = new FormControl('');
  spol = new Spol();
  constructor(private route: ActivatedRoute,
    private router: Router,
    private spolService: SpoloviService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.spolService.get(params["id"]).subscribe(data => {
        this.spol.id = data.id;
        this.spol.naziv = data.naziv;
        this.setValues();
      })
    })
  }
  private setValues() {
    this.name.setValue(this.spol.naziv);
  }
  gotoList() {
    this.router.navigate(['/spolovi']);
  }
  onSubmit() {
    if (this.name.valid) {
      let spol = new Spol(this.spol.id, this.name.value);

      this.spolService.update(spol).subscribe(
        response => { this.gotoList() }
      );
    }
    else {
      this.name.markAsTouched();
    }

  }

}
