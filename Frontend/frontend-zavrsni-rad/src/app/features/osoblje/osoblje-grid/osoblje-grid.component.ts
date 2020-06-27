import { Component, OnInit, ViewChild } from '@angular/core';
import { Osoblje } from 'src/app/modeli/osoblje-model';
import { OsobljeService } from '../../services/osoblje-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-osoblje-grid',
  templateUrl: './osoblje-grid.component.html',
  styleUrls: ['./osoblje-grid.component.scss']
})
export class OsobljeGridComponent implements OnInit {

  displayedColumns: string[] = [ 'osoba', 'momcad', 'dozvolaZaRad', 'datumIstekaDozvole', 'actions'];
  resultsLength;
  osoblje: Osoblje[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private osobljeService: OsobljeService, private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "osoba";
    this.sortDirection = "asc";

    this.osobljeService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.osobljeService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.osoblje = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.osobljeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.osoblje = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.osobljeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.osoblje = data;
      }
    );
  }

  deleteData(id: number) {
    this.osobljeService.delete(id).subscribe(
      response => {
        if (response) {

          this.osobljeService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.osoblje = data;
            }
          );
        } else {

        }
      }
    )
  }

  editOsoblje(id: number) {
    this.router.navigate(['osoblje-edit', id]);
  }
}
