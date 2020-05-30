import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Uloga } from 'src/app/modeli/uloga-model';
import { ActivatedRoute, Router } from '@angular/router';
import { UlogeService } from '../../services/uloge-service';

@Component({
  selector: 'app-uloge-edit',
  templateUrl: './uloge-edit.component.html',
  styleUrls: ['./uloge-edit.component.scss']
})
export class UlogeEditComponent implements OnInit {

  name = new FormControl('');
  uloga = new Uloga();
  constructor(private route: ActivatedRoute,
    private router: Router,
    private ulogaService: UlogeService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.ulogaService.get(params["id"]).subscribe(data => {
        this.uloga.id = data.id;
        this.uloga.naziv = data.naziv;
        this.setValues();
      })
    })
  }
  private setValues() {
    this.name.setValue(this.uloga.naziv);
  }
  gotoList() {
    this.router.navigate(['/uloge']);
  }
  onSubmit() {
    if (this.name.valid) {
      let uloga = new Uloga(this.uloga.id, this.name.value);

      this.ulogaService.update(uloga).subscribe(
        response => { this.gotoList() }
      );
    }
    else {
      this.name.markAsTouched();
    }

  }

}
