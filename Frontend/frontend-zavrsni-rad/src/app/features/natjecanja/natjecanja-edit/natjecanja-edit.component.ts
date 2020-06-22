import { Component, OnInit } from '@angular/core';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { NatjecanjaService } from '../../services/natjecanja-service';
import { FormControl } from '@angular/forms';
import { Drzava } from 'src/app/modeli/drzava-model';
import { ActivatedRoute, Router } from '@angular/router';
import { DrzaveService } from '../../services/drzave-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

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

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private natjecanjeService: NatjecanjaService,
    private drzaveService: DrzaveService,
    private _snackBar: MatSnackBar) { }

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
        response => { 
          this._snackBar.open('Natjecanje uspješno ažurirano', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList()
         }
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
