import { Component, OnInit } from '@angular/core';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LokacijeService } from '../../services/lokacije-service';
import { DrzaveService } from '../../services/drzave-service';
import { Drzava } from 'src/app/modeli/drzava-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-lokacije-add',
  templateUrl: './lokacije-add.component.html',
  styleUrls: ['./lokacije-add.component.scss']
})
export class LokacijeAddComponent implements OnInit {

  address = new FormControl('');
  country = new FormControl('');

  public drzave: Drzava[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService,
    private lokacijaService: LokacijeService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.drzaveService.getAllCountries().subscribe(
      (data) => {
        this.drzave = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/lokacije']);
  }

  onSubmit(){
    if (this.address.valid) {
      let lokacija = new Lokacija(null,this.address.value, this.country.value);
      this.lokacijaService.add(lokacija).subscribe(
        response => {
          this._snackBar.open('Lokacija uspješno dodana', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList()
        }
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
