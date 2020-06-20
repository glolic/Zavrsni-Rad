import { Component, OnInit } from '@angular/core';
import { Klub } from 'src/app/modeli/klub-model';
import { MomcadService } from '../../services/momcad-service';
import { KluboviService } from '../../services/klubovi-service';
import { Momcad } from 'src/app/modeli/momcad-model';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-momcadi-edit',
  templateUrl: './momcadi-edit.component.html',
  styleUrls: ['./momcadi-edit.component.scss']
})
export class MomcadiEditComponent implements OnInit {

  name = new FormControl('');
  club = new FormControl('');

  klubCollection: Klub[];

  momcad = new Momcad();
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private momcadService: MomcadService,
    private klubService: KluboviService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.momcadService.get(params["id"]).subscribe(data => {
        this.momcad.id = data.id;
        this.momcad.naziv = data.naziv;
        this.momcad.klub = data.klub;
        this.setValues();
      })
    })
  }
  
  ngAfterContentInit() {
    this.klubService.getAllClubs().subscribe(
      (data) => {
        this.klubCollection = data;
      }
    );
  }
  
  private setValues() {
    this.name.setValue(this.momcad.naziv);
    this.club.setValue(this.momcad.klub);
  }

  gotoList() {
    this.router.navigate(['/momcadi']);
  }

  onSubmit() {
    if (this.name.valid) {
      let momcad = new Momcad(this.momcad.id, this.name.value, this.club.value);

      this.momcadService.update(momcad).subscribe(
        response => { this.gotoList() }
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
