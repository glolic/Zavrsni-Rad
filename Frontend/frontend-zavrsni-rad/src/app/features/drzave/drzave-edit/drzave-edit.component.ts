import { Component, OnInit } from '@angular/core';
import { Drzava } from 'src/app/modeli/drzava-model';
import { DrzaveService } from '../../services/drzave-service';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-drzave-edit',
  templateUrl: './drzave-edit.component.html',
  styleUrls: ['./drzave-edit.component.scss']
})
export class DrzaveEditComponent implements OnInit {

  name = new FormControl('');
  code = new FormControl('');
  drzava = new Drzava();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzavaService: DrzaveService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.drzavaService.get(params["id"]).subscribe(data => {
        this.drzava.id = data.id;
        this.drzava.nazivDrzave = data.nazivDrzave;
        this.drzava.oznaka = data.oznaka;
        this.setValues();
      })
    })
  }
  private setValues() {
    this.name.setValue(this.drzava.nazivDrzave);
    this.code.setValue(this.drzava.oznaka);
  }
  gotoList() {
    this.router.navigate(['/drzave']);
  }
  onSubmit() {
    if (this.name.valid) {
      let drzava = new Drzava(this.drzava.id, this.name.value, this.code.value);

      this.drzavaService.update(drzava).subscribe(
        response => { 
          this._snackBar.open('Država uspješno ažurirana', 'x', {
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

}
