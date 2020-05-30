import { Component, OnInit, ViewChild } from '@angular/core';
import { Partner } from 'src/app/modeli/partneri-model';
import { PartneriService } from '../../services/partner-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-partneri-grid',
  templateUrl: './partneri-grid.component.html',
  styleUrls: ['./partneri-grid.component.scss']
})
export class PartneriGridComponent implements OnInit {

  displayedColumns: string[] = [ 'nazivPartnera', 'lokacija', 'actions'];
  resultsLength;
  partneri: Partner[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private partneriService: PartneriService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "nazivPartnera";
    this.sortDirection = "asc";

    this.partneriService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.partneriService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.partneri = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.partneriService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.partneri = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.partneriService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.partneri = data;
      }
    );
  }

  deleteData(id: number) {
    this.partneriService.delete(id).subscribe(
      response => {
        if (response) {

          this.partneriService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.partneri = data;
            }
          );
        } else {

        }
      }
    )
  }

  editPartner(id: number) {
    this.router.navigate(['partneri-edit', id]);
  }

}
