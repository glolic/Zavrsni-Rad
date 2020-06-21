import { Component, OnInit, ViewChild } from '@angular/core';
import { Igrac } from 'src/app/modeli/igrac-model';
import { IgraciService } from '../../services/igraci-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-igraci-grid',
  templateUrl: './igraci-grid.component.html',
  styleUrls: ['./igraci-grid.component.scss']
})
export class IgraciGridComponent implements OnInit {

  displayedColumns: string[] = [ 'osoba', 'pozicija', 'brojDresa', 'actions'];
  resultsLength;
  igraci: Igrac[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private igraciService: IgraciService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "naziv";
    this.sortDirection = "asc";

    this.igraciService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.igraciService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.igraci = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.igraciService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.igraci = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.igraciService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.igraci = data;
      }
    );
  }

  deleteData(id: number) {
    this.igraciService.delete(id).subscribe(
      response => {
        if (response) {

          this.igraciService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.igraci = data;
            }
          );
        } else {

        }
      }
    )
  }

  editIgrac(id: number) {
    this.router.navigate(['igraci-edit', id]);
  }

}
