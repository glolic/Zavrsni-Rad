import { Component, OnInit, ViewChild } from '@angular/core';
import { Momcad } from 'src/app/modeli/momcad-model';
import { MomcadService } from '../../services/momcad-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-momcadi-grid',
  templateUrl: './momcadi-grid.component.html',
  styleUrls: ['./momcadi-grid.component.scss']
})
export class MomcadiGridComponent implements OnInit {

  displayedColumns: string[] = [ 'naziv', 'klub', 'actions'];
  resultsLength;
  momcadi: Momcad[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private momcadiService: MomcadService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "adresa";
    this.sortDirection = "asc";

    this.momcadiService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.momcadiService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.momcadi = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.momcadiService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.momcadi = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.momcadiService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.momcadi = data;
      }
    );
  }

  deleteData(id: number) {
    this.momcadiService.delete(id).subscribe(
      response => {
        if (response) {

          this.momcadiService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.momcadi = data;
            }
          );
        } else {

        }
      }
    )
  }

  editMomcad(id: number) {
    this.router.navigate(['momcadi-edit', id]);
  }

}
