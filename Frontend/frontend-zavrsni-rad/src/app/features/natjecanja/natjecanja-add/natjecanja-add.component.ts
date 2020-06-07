import { Component, OnInit } from '@angular/core';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { FormControl } from '@angular/forms';
import { Drzava } from 'src/app/modeli/drzava-model';
import { ActivatedRoute, Router } from '@angular/router';
import { DrzaveService } from '../../services/drzave-service';
import { NatjecanjaService } from '../../services/natjecanja-service';

@Component({
  selector: 'app-natjecanja-add',
  templateUrl: './natjecanja-add.component.html',
  styleUrls: ['./natjecanja-add.component.scss']
})
export class NatjecanjaAddComponent implements OnInit {

  name = new FormControl('');
  country = new FormControl('');

  public drzaveCollection: Drzava[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService,
    private natjecanjeService: NatjecanjaService){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.drzaveService.getAllCountries().subscribe(
      (data) => {
        this.drzaveCollection = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/natjecanja']);
  }

  onSubmit(){
    if (this.name.valid) {
      let natjecanje = new Natjecanje(null,this.name.value, this.country.value);
      this.natjecanjeService.add(natjecanje).subscribe(
        response => {this.gotoList()}
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
