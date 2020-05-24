import { Component, OnInit, ViewChild } from '@angular/core';
import { Lokacija } from 'src/app/modeli/lokacija-model';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { LokacijeService } from '../../services/lokacije-service';

@Component({
  selector: 'app-lokacije-grid',
  templateUrl: './lokacije-grid.component.html',
  styleUrls: ['./lokacije-grid.component.scss']
})
export class LokacijeGridComponent implements OnInit {

  displayedColumns: string[] = [ 'adresa', 'drzava', 'actions'];
  resultsLength;
  lokacije: Lokacija[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private lokacijeService: LokacijeService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "adresa";
    this.sortDirection = "asc";

    this.lokacijeService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.lokacijeService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.lokacije = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.lokacijeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.lokacije = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.lokacijeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.lokacije = data;
      }
    );
  }

  deleteData(id: number) {
    this.lokacijeService.delete(id).subscribe(
      response => {
        if (response) {

          this.lokacijeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.lokacije = data;
            }
          );
        } else {

        }
      }
    )
  }

  editLokacija(id: number) {
    this.router.navigate(['lokacije-edit', id]);
  }

}
