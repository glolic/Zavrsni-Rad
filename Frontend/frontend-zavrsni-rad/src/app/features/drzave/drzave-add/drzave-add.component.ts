import { Component, OnInit } from '@angular/core';
import { DrzaveService } from '../../services/drzave-service';
import { Drzava } from 'src/app/modeli/drzava-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-drzave-add',
  templateUrl: './drzave-add.component.html',
  styleUrls: ['./drzave-add.component.scss']
})
export class DrzaveAddComponent implements OnInit {

  name = new FormControl('');
  code = new FormControl('');

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  

  constructor(private route: ActivatedRoute,
    private router: Router,
    private drzaveService: DrzaveService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/drzave']);
  }

  onSubmit(){
    if (this.name.valid) {
      let drzava = new Drzava(null,this.name.value, this.code.value);
      this.drzaveService.add(drzava).subscribe(
        response => {
          this._snackBar.open('Država uspješno dodana', 'x', {
            duration: 5000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.gotoList()
        }
      );
    }
    else {
      this.name.markAsTouched();
    }
  
  }

}
