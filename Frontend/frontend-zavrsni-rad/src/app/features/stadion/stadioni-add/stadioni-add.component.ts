import { Component, OnInit } from '@angular/core';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { Stadion } from 'src/app/modeli/stadion-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StadioniService } from '../../services/stadioni-service';
import { LokacijeService } from '../../services/lokacije-service';

@Component({
  selector: 'app-stadioni-add',
  templateUrl: './stadioni-add.component.html',
  styleUrls: ['./stadioni-add.component.scss']
})
export class StadioniAddComponent implements OnInit {

  name = new FormControl('');
  capacity = new FormControl('');
  location = new FormControl('');

  public lokacijaCollection: Lokacija[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private stadionService: StadioniService,
    private lokacijaService: LokacijeService){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.lokacijaService.getAllLocations().subscribe(
      (data) => {
        this.lokacijaCollection = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/stadioni']);
  }

  onSubmit(){
    if (this.name.valid) {
      let stadion = new Stadion(null,this.name.value, this.capacity.value, this.location.value);
      this.stadionService.add(stadion).subscribe(
        response => {this.gotoList()}
      );
    }
    else {
      this.name.markAsTouched();
    }
  }

  displayFn(lokacija: Lokacija): string {
    return lokacija && lokacija.adresa ? lokacija.adresa : '';
  }

}
