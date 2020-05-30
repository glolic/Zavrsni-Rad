import { Component, OnInit, ViewChild } from '@angular/core';
import { DrzaveService } from '../../services/drzave-service';
import { Drzava } from 'src/app/modeli/drzava-model';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-drzave-grid',
  templateUrl: './drzave-grid.component.html',
  styleUrls: ['./drzave-grid.component.scss']
})
export class DrzaveGridComponent implements OnInit {

  displayedColumns: string[] = ['nazivDrzave', 'oznaka', 'actions'];
  resultsLength;
  drzave: Drzava[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private drzaveService: DrzaveService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "nazivDrzave";
    this.sortDirection = "desc";

    this.drzaveService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.drzaveService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.drzave = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.drzaveService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.drzave = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.drzaveService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.drzave = data;
      }
    );
  }

  deleteData(id: number) {
    this.drzaveService.delete(id).subscribe(
      response => {
        if (response) {

          this.drzaveService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.drzave = data;
            }
          );
        } else {

        }
      }
    )
  }

  editDrzava(id: number) {
    this.router.navigate(['drzave-edit', id]);
  }

}
