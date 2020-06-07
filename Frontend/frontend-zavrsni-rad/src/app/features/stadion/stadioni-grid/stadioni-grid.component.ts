import { Component, OnInit, ViewChild } from '@angular/core';
import { Stadion } from 'src/app/modeli/stadion-model';
import { StadioniService } from '../../services/stadioni-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stadioni-grid',
  templateUrl: './stadioni-grid.component.html',
  styleUrls: ['./stadioni-grid.component.scss']
})
export class StadioniGridComponent implements OnInit {

  displayedColumns: string[] = [ 'naziv', 'kapacitet', 'lokacija', 'actions'];
  resultsLength;
  stadioni: Stadion[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private stadionService: StadioniService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "naziv";
    this.sortDirection = "asc";

    this.stadionService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.stadionService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.stadioni = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.stadionService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.stadioni = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.stadionService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.stadioni = data;
      }
    );
  }

  deleteData(id: number) {
    this.stadionService.delete(id).subscribe(
      response => {
        if (response) {

          this.stadionService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.stadioni = data;
            }
          );
        } else {

        }
      }
    )
  }

  editStadion(id: number) {
    this.router.navigate(['stadioni-edit', id]);
  }
}
