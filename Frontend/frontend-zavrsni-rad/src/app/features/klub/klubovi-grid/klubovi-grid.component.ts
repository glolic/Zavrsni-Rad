import { Component, OnInit, ViewChild } from '@angular/core';
import { Klub } from 'src/app/modeli/klub-model';
import { KluboviService } from '../../services/klubovi-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-klubovi-grid',
  templateUrl: './klubovi-grid.component.html',
  styleUrls: ['./klubovi-grid.component.scss']
})
export class KluboviGridComponent implements OnInit {

  displayedColumns: string[] = [ 'naziv', 'godinaOsnivanja', 'sjedisteKluba', 'stadion', 'actions'];
  resultsLength;
  klubovi: Klub[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private kluboviService: KluboviService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "naziv";
    this.sortDirection = "asc";

    this.kluboviService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.kluboviService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.klubovi = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.kluboviService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.klubovi = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.kluboviService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.klubovi = data;
      }
    );
  }

  deleteData(id: number) {
    this.kluboviService.delete(id).subscribe(
      response => {
        if (response) {

          this.kluboviService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.klubovi = data;
            }
          );
        } else {

        }
      }
    )
  }

  editKlub(id: number) {
    this.router.navigate(['klubovi-edit', id]);
  }
}
