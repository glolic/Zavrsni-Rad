import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SpoloviService } from '../../services/spolovi-service';
import { ActivatedRoute, Router } from '@angular/router';
import { Spol } from 'src/app/modeli/spol-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-spolovi-add',
  templateUrl: './spolovi-add.component.html',
  styleUrls: ['./spolovi-add.component.scss']
})
export class SpoloviAddComponent implements OnInit {

  name = new FormControl('');

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private spolService: SpoloviService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/spolovi']);
  }

  onSubmit(){
    if (this.name.valid) {
      let spol = new Spol(null,this.name.value);
      this.spolService.add(spol).subscribe(
        response => {
          this._snackBar.open('Spol uspješno dodan', 'x', {
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
