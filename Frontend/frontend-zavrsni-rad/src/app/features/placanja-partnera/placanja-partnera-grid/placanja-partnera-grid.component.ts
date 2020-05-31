import { Component, OnInit, ViewChild } from '@angular/core';
import { PlacanjaPartnera } from 'src/app/modeli/placanje-partnera-model';
import { PartneriService } from '../../services/partner-service';
import { PageEvent, MatPaginator, MatSort } from '@angular/material';
import { PlacanjaPartneraService } from '../../services/placanja-partnera-service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-placanja-partnera-grid',
  templateUrl: './placanja-partnera-grid.component.html',
  styleUrls: ['./placanja-partnera-grid.component.scss']
})
export class PlacanjaPartneraGridComponent implements OnInit {

  displayedColumns: string[] = ['razlogPlacanja', 'iznos', 'partner', 'placeno', 'actions'];
  resultsLength;
  svaPlacanjaPartnera: PlacanjaPartnera[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private placanjaPartneraService: PlacanjaPartneraService, private http: HttpClient,
              private router: Router, private partnerService: PartneriService) { }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "iznos";
    this.sortDirection = "asc";

    this.placanjaPartneraService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.placanjaPartneraService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.svaPlacanjaPartnera = data;
      }
    )
  }

  getServerData(event: PageEvent) {

    this.placanjaPartneraService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.svaPlacanjaPartnera = data;

      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.placanjaPartneraService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.svaPlacanjaPartnera = data;
      }
    );
  }

  deleteData(id: number) {
    this.placanjaPartneraService.delete(id).subscribe(
      response => {
        if (response) {

          this.placanjaPartneraService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.svaPlacanjaPartnera = data;
            }
          );
        } else {

        }
      }
    )
  }

  editPlacanjePartnera(id: number) {
    this.router.navigate(['placanja-partnera-edit', id]);
  }
}
