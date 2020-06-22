import { Component, OnInit } from '@angular/core';
import { Partner } from 'src/app/modeli/partneri-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PartneriService } from '../../services/partner-service';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { LokacijeService } from '../../services/lokacije-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-partneri-edit',
  templateUrl: './partneri-edit.component.html',
  styleUrls: ['./partneri-edit.component.scss']
})
export class PartneriEditComponent implements OnInit {

  partnerName = new FormControl('');
  location = new FormControl('');

  lokacijaCollection: Lokacija[];

  partner = new Partner();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private partnerService: PartneriService,
    private lokacijaService: LokacijeService,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.partnerService.get(params["id"]).subscribe(data => {
        this.partner.id = data.id;
        this.partner.nazivPartnera = data.nazivPartnera;
        this.partner.lokacija = data.lokacija;
        this.setValues();
      })
    })
  }

  ngAfterContentInit() {
    this.lokacijaService.getAllLocations().subscribe(
      (data) => {
        this.lokacijaCollection = data;
      }
    );
  }
  
  private setValues() {
    this.partnerName.setValue(this.partner.nazivPartnera);
    this.location.setValue(this.partner.lokacija);
  }

  gotoList() {
    this.router.navigate(['/partneri']);
  }

  onSubmit() {
    if (this.partnerName.valid) {
      let lokacija = new Partner(this.partner.id, this.partnerName.value, this.location.value);

      this.partnerService.update(lokacija).subscribe(
        response => { 
          this._snackBar.open('Partner uspješno ažuriran', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList() 
        }
      );
    }
    else {
      this.partnerName.markAsTouched();
    }
  }

  displayFn(lokacija: Lokacija): string {
    return lokacija && lokacija.adresa ? lokacija.adresa : '';
  }

}
