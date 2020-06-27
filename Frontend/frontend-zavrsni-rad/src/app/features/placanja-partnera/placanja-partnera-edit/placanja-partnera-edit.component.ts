import { Component, OnInit } from '@angular/core';
import { PlacanjaPartnera } from 'src/app/modeli/placanje-partnera-model';
import { Partner } from 'src/app/modeli/partneri-model';
import { FormControl } from '@angular/forms';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, DateAdapter, MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { PlacanjaPartneraService } from '../../services/placanja-partnera-service';
import { PartneriService } from '../../services/partner-service';

@Component({
  selector: 'app-placanja-partnera-edit',
  templateUrl: './placanja-partnera-edit.component.html',
  styleUrls: ['./placanja-partnera-edit.component.scss']
})
export class PlacanjaPartneraEditComponent implements OnInit {

  reason = new FormControl('');
  amount = new FormControl('');
  partner = new FormControl('');
  dateOfPayment = new FormControl('');

  public partneri: Partner[];

  placanjaPartneri = new PlacanjaPartnera();

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  public isReadOnly: boolean;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private placanjaPartneraService: PlacanjaPartneraService,
    private partneriService: PartneriService,
    private _adapter: DateAdapter<any>,
    private _snackBar: MatSnackBar
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.placanjaPartneraService.get(params["id"]).subscribe(data => {
        this.placanjaPartneri.id = data.id;
        this.placanjaPartneri.partner = data.partner;
        this.placanjaPartneri.razlogPlacanja = data.razlogPlacanja;
        this.placanjaPartneri.iznos = data.iznos;
        this.placanjaPartneri.datumPlacanja = data.datumPlacanja;
        this.setValues();
      })
    })
    this._adapter.setLocale('hr');
  }

  ngAfterContentInit() {
    this.partneriService.getAllPartners().subscribe(
      (data) => {
        this.partneri = data;
      }
    );
  }

  private setValues() {
    this.reason.setValue(this.placanjaPartneri.razlogPlacanja);
    this.amount.setValue(this.placanjaPartneri.iznos);
    this.dateOfPayment.setValue(this.placanjaPartneri.datumPlacanja);
    this.partner.setValue(this.placanjaPartneri.partner);
  }

  gotoList() {
    this.router.navigate(['/placanja-partnera']);
  }

  onSubmit() {
    var formattedDate1 = new Date(this.dateOfPayment.value);
    var timeZoneDifference = (formattedDate1.getTimezoneOffset() / 60) * -1; 
    formattedDate1.setTime(formattedDate1.getTime() + (timeZoneDifference * 60) * 60 * 1000);
    formattedDate1.toISOString();
    
    if (this.partner.valid) {
      let pPartnera = new PlacanjaPartnera(this.placanjaPartneri.id, this.reason.value, this.amount.value, this.partner.value, formattedDate1);
      
      this.placanjaPartneraService.update(pPartnera).subscribe(
        response => { 
          this._snackBar.open('Plaćanje partnera uspješno ažurirano', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList() 
        }
      );
    }
    else {
      this.partner.markAsTouched();
    }
  }

  displayFn(partner: Partner): string {
    return partner && partner.nazivPartnera ? partner.nazivPartnera : '';
  }

}
