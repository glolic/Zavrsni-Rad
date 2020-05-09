import { Component, OnInit, ViewChild } from '@angular/core';
import { Spol } from 'src/app/modeli/spol-model';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { SpolService } from '../../services/spolovi-service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-spolovi-grid',
  templateUrl: './spolovi-grid.component.html',
  styleUrls: ['./spolovi-grid.component.scss']
})
export class SpoloviGridComponent implements OnInit {

  displayedColumns: string[] = ['id', 'naziv', 'actions'];
  resultsLength;
  data: Spol[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isLoadingResults = false;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, {static:false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static:false}) sort: MatSort;

  constructor(private spolService: SpolService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "id";
    this.sortDirection = "asc";

    this.isLoadingResults = true;
    this.spolService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.spolService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.data = data;
        this.isLoadingResults = false;
      }
    )
  }
  getServerData(event: PageEvent) {
    this.isLoadingResults = true;

    this.spolService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.data = data;
        this.isLoadingResults = false;

      }
    );
  }
  sortData(event: any) {
    this.paginator.pageIndex = 0;
    
    this.isLoadingResults = true;
    this.spolService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.data = data;
        this.isLoadingResults = false;
      }
    );
  }
  deleteData(id: number) {
    this.spolService.delete(id).subscribe(
      response => {
        if (response) {
          
          this.spolService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.data = data;
              this.isLoadingResults = false;
            }
          );
        } else {

        }
      }
    )
  }
  editUser(id: number) {
    this.router.navigate(['korisnici-edit', id]);

  }
}
