import { Component, OnInit } from '@angular/core';
import { Partner } from 'src/app/modeli/partneri-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PartneriService } from '../../services/partner-service';

@Component({
  selector: 'app-partneri-edit',
  templateUrl: './partneri-edit.component.html',
  styleUrls: ['./partneri-edit.component.scss']
})
export class PartneriEditComponent implements OnInit {

  partnerName = new FormControl('');
  location = new FormControl('');

  partner = new Partner();

  constructor(private route: ActivatedRoute,
    private router: Router,
    private partnerService: PartneriService) { }

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
        response => { this.gotoList() }
      );
    }
    else {
      this.partnerName.markAsTouched();
    }
  }

  displayFn(partner: Partner): string {
    return partner && partner.nazivPartnera ? partner.nazivPartnera : '';
  }

}
