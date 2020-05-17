import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SpoloviService } from '../../services/spolovi-service';
import { ActivatedRoute, Router } from '@angular/router';
import { Spol } from 'src/app/modeli/spol-model';

@Component({
  selector: 'app-spolovi-add',
  templateUrl: './spolovi-add.component.html',
  styleUrls: ['./spolovi-add.component.scss']
})
export class SpoloviAddComponent implements OnInit {

  name = new FormControl('');

  constructor(private route: ActivatedRoute,
    private router: Router,
    private spolService: SpoloviService){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/spolovi']);
  }

  onSubmit(){
    if (this.name.valid) {
      let spol = new Spol(null,this.name.value);
      this.spolService.add(spol).subscribe(
        response => {this.gotoList()}
      );
    }
    else {
      this.name.markAsTouched();
    }
  
  }
}
