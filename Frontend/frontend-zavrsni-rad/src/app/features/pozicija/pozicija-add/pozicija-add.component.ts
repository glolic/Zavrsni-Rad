import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PozicijeService } from '../../services/pozicije-service';
import { Pozicija } from 'src/app/modeli/pozicija-model';

@Component({
  selector: 'app-pozicija-add',
  templateUrl: './pozicija-add.component.html',
  styleUrls: ['./pozicija-add.component.scss']
})
export class PozicijaAddComponent implements OnInit {

  name = new FormControl('');

  constructor(private route: ActivatedRoute,
    private router: Router,
    private pozicijaService: PozicijeService){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/pozicije']);
  }

  onSubmit(){
    if (this.name.valid) {
      let pozicija = new Pozicija(null,this.name.value);
      this.pozicijaService.add(pozicija).subscribe(
        response => {this.gotoList()}
      );
    }
    else {
      this.name.markAsTouched();
    }
  
  }

}
