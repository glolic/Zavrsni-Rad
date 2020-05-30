import { Component, OnInit, ViewChild } from '@angular/core';
import { Uloga } from 'src/app/modeli/uloga-model';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UlogeService } from '../../services/uloge-service';

@Component({
  selector: 'app-uloge-grid',
  templateUrl: './uloge-grid.component.html',
  styleUrls: ['./uloge-grid.component.scss']
})
export class UlogeGridComponent implements OnInit {

  displayedColumns: string[] = ['naziv', 'actions'];
  resultsLength;
  uloge: Uloga[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private ulogaService: UlogeService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "id";
    this.sortDirection = "asc";

    this.ulogaService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.ulogaService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.uloge = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.ulogaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.uloge = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.ulogaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.uloge = data;
      }
    );
  }

  deleteData(id: number) {
    this.ulogaService.delete(id).subscribe(
      response => {
        if (response) {

          this.ulogaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.uloge = data;
            }
          );
        } else {

        }
      }
    )
  }

  editUloga(id: number) {
    this.router.navigate(['uloge-edit', id]);
  }

}
