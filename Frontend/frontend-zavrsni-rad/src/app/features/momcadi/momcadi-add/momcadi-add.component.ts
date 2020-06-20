import { Component, OnInit } from '@angular/core';
import { Klub } from 'src/app/modeli/klub-model';
import { KluboviService } from '../../services/klubovi-service';
import { MomcadService } from '../../services/momcad-service';
import { Momcad } from 'src/app/modeli/momcad-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-momcadi-add',
  templateUrl: './momcadi-add.component.html',
  styleUrls: ['./momcadi-add.component.scss']
})
export class MomcadiAddComponent implements OnInit {

  name = new FormControl('');
  club = new FormControl('');

  public klubCollection: Klub[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private klubService: KluboviService,
    private momcadService: MomcadService){}

  ngOnInit() {
    
  }

  ngAfterContentInit() {
    this.klubService.getAllClubs().subscribe(
      (data) => {
        this.klubCollection = data;
      }
    );
  }

  gotoList() {
    this.router.navigate(['/momcadi']);
  }

  onSubmit(){
    if (this.name.valid) {
      let momcad = new Momcad(null,this.name.value, this.club.value);
      this.momcadService.add(momcad).subscribe(
        response => {this.gotoList()}
      );
    }
    else {
      this.name.markAsTouched();
    }
  }

  displayFn(klub: Klub): string {
    return klub && klub.naziv ? klub.naziv : '';
  }

}
