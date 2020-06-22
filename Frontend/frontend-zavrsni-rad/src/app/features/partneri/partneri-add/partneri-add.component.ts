import { Component, OnInit } from '@angular/core';
import { PartneriService } from '../../services/partner-service';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LokacijeService } from '../../services/lokacije-service';
import { Partner } from 'src/app/modeli/partneri-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-partneri-add',
  templateUrl: './partneri-add.component.html',
  styleUrls: ['./partneri-add.component.scss']
})
export class PartneriAddComponent implements OnInit {

  partnerName = new FormControl('');
  location = new FormControl('');

  public lokacija: Lokacija[];

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';


  constructor(private route: ActivatedRoute,
    private router: Router,
    private partnerService: PartneriService,
    private lokacijaService: LokacijeService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.lokacijaService.getAllLocations().subscribe(
      (data) => {
        this.lokacija = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/partneri']);
  }

  onSubmit(){
    if (this.partnerName.valid) {
      let partner = new Partner(null,this.partnerName.value, this.location.value);
      this.partnerService.add(partner).subscribe(
        response => {
          this._snackBar.open('Partner uspješno dodan', 'x', {
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
