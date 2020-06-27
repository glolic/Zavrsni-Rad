import { Component, OnInit, ViewChild } from '@angular/core';
import { Osoba } from 'src/app/modeli/osoba-model';
import { OsobeService } from '../../services/osobe-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-osobe-grid',
  templateUrl: './osobe-grid.component.html',
  styleUrls: ['./osobe-grid.component.scss']
})
export class OsobeGridComponent implements OnInit {

  displayedColumns: string[] = [ 'ime', 'prezime', 'datumRodenja', 'drzavaRodenja', 'oib', 'spol', 'uloga', 'actions'];
  resultsLength;
  osobe: Osoba[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(
    private osobeService: OsobeService, 
    private http: HttpClient, 
    private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "naziv";
    this.sortDirection = "asc";

    this.osobeService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.osobeService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.osobe = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.osobeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.osobe = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.osobeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.osobe = data;
      }
    );
  }

  deleteData(id: number) {
    this.osobeService.delete(id).subscribe(
      response => {
        if (response) {

          this.osobeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.osobe = data;
            }
          );
        } else {

        }
      }
    )
  }

  editOsoba(id: number) {
    this.router.navigate(['osobe-edit', id]);
  }
}
