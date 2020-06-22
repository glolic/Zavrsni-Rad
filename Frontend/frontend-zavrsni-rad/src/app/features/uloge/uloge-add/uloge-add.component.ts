import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UlogeService } from '../../services/uloge-service';
import { Uloga } from 'src/app/modeli/uloga-model';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-uloge-add',
  templateUrl: './uloge-add.component.html',
  styleUrls: ['./uloge-add.component.scss']
})
export class UlogeAddComponent implements OnInit {

  name = new FormControl('');

  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';


  constructor(private route: ActivatedRoute,
    private router: Router,
    private ulogaService: UlogeService,
    private _snackBar: MatSnackBar){}

  ngOnInit() {
    
  }

  gotoList() {
    this.router.navigate(['/uloge']);
  }

  onSubmit(){
    if (this.name.valid) {
      let uloga = new Uloga(null,this.name.value);
      this.ulogaService.add(uloga).subscribe(
        response => {
          this._snackBar.open('Stadion uspješno dodan', 'x', {
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
