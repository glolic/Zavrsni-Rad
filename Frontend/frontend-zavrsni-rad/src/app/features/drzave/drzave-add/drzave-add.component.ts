import { Component, OnInit } from '@angular/core';
import { DrzaveService } from '../../services/drzave-service';
import { Drzava } from 'src/app/modeli/drzava-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-drzave-add',
  templateUrl: './drzave-add.component.html',
  styleUrls: ['./drzave-add.component.scss']
})
export class DrzaveAddComponent implements OnInit {

  name = new FormControl('');
  code = new FormControl('');

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/drzave']);
  }

  onSubmit(){
    if (this.name.valid) {
      let drzava = new Drzava(null,this.name.value, this.code.value);
      this.drzaveService.add(drzava).subscribe(
        response => {this.gotoList()}
      );
    }
    else {
      this.name.markAsTouched();
    }
  
  }

}
