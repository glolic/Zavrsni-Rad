import { Component, OnInit, ViewChild } from '@angular/core';
import { Pozicija } from 'src/app/modeli/pozicija-model';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { PozicijeService } from '../../services/pozicije-service';

@Component({
  selector: 'app-pozicija-grid',
  templateUrl: './pozicija-grid.component.html',
  styleUrls: ['./pozicija-grid.component.scss']
})
export class PozicijaGridComponent implements OnInit {

  displayedColumns: string[] = ['naziv', 'actions'];
  resultsLength;
  pozicije: Pozicija[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private pozicijaService: PozicijeService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "id";
    this.sortDirection = "asc";

    this.pozicijaService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.pozicijaService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.pozicije = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.pozicijaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.pozicije = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.pozicijaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.pozicije = data;
      }
    );
  }

  deleteData(id: number) {
    this.pozicijaService.delete(id).subscribe(
      response => {
        if (response) {

          this.pozicijaService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.pozicije = data;
            }
          );
        } else {

        }
      }
    )
  }

  editPozicija(id: number) {
    this.router.navigate(['pozicije-edit', id]);
  }

}
