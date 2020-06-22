import { Component, OnInit } from '@angular/core';
import { Partner } from 'src/app/modeli/partneri-model';
import { PartneriService } from '../../services/partner-service';
import { PlacanjaPartnera } from 'src/app/modeli/placanje-partnera-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PlacanjaPartneraService } from '../../services/placanja-partnera-service';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-placanja-partnera-add',
  templateUrl: './placanja-partnera-add.component.html',
  styleUrls: ['./placanja-partnera-add.component.scss']
})
export class PlacanjaPartneraAddComponent implements OnInit {

  reason = new FormControl('');
  amount = new FormControl('');
  partner = new FormControl('');
  isPaid = new FormControl('');

  public partneri: Partner[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private placanjaPartneraService: PlacanjaPartneraService,
    private partneriService: PartneriService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.partneriService.getAllPartners().subscribe(
      (data) => {
        this.partneri = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/placanja-partnera']);
  }

  onSubmit(){
    if (this.reason.valid && this.amount.valid) {
      let placanjaPartnera = new PlacanjaPartnera(null, this.reason.value, this.amount.value, this.partner.value, this.isPaid.value);
      this.placanjaPartneraService.add(placanjaPartnera).subscribe(
        response => {
          this._snackBar.open('Plaćanje uspješno dodan', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList()
        }
      );
    }
    else {
      this.reason.markAsTouched();
      this.amount.markAsTouched();
    }
  }

  displayFn(partner: Partner): string {
    return partner && partner.nazivPartnera ? partner.nazivPartnera : '';
  }

}
