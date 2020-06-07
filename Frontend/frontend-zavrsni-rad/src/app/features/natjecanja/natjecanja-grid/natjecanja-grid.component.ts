import { Component, OnInit, ViewChild } from '@angular/core';
import { Natjecanje } from 'src/app/modeli/natjecanje-model';
import { NatjecanjaService } from '../../services/natjecanja-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-natjecanja-grid',
  templateUrl: './natjecanja-grid.component.html',
  styleUrls: ['./natjecanja-grid.component.scss']
})
export class NatjecanjaGridComponent implements OnInit {

  displayedColumns: string[] = [ 'imeNatjecanja', 'drzava', 'actions'];
  resultsLength;
  natjecanja: Natjecanje[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private natjecanjaService: NatjecanjaService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "adresa";
    this.sortDirection = "asc";

    this.natjecanjaService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.natjecanjaService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.natjecanja = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.natjecanjaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.natjecanja = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.natjecanjaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.natjecanja = data;
      }
    );
  }

  deleteData(id: number) {
    this.natjecanjaService.delete(id).subscribe(
      response => {
        if (response) {

          this.natjecanjaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.natjecanja = data;
            }
          );
        } else {

        }
      }
    )
  }

  editNatjecanje(id: number) {
    this.router.navigate(['natjecanja-edit', id]);
  }

}
