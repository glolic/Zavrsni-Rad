import { Component, OnInit, ViewChild } from '@angular/core';
import { Utakmica } from 'src/app/modeli/utakmica-model';
import { UtakmiceService } from '../../services/utakmice-service';
import { PageEvent, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Momcad } from 'src/app/modeli/momcad-model';
import { MomcadService } from '../../services/momcad-service';

@Component({
  selector: 'app-utakmice-grid',
  templateUrl: './utakmice-grid.component.html',
  styleUrls: ['./utakmice-grid.component.scss']
})
export class UtakmiceGridComponent implements OnInit {

  displayedColumns: string[] = ['datumUtakmice', 'momcad1', 'momcad2', 'rezultat', 'brojPosjetitelja', 'natjecanje', 'actions'];
  resultsLength;
  filterValues = {};
  utakmice: Utakmica[];
  teamsCollection: Momcad[];
  pageEvent: PageEvent;
  datasource: null;
  pageIndex: number;
  pageSize: number;
  sortDirection: string;
  sortActive: string;
  isRateLimitReached = false;
  dataSource = new MatTableDataSource();

  filterSelectObj = [];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(
    private utakmiceService: UtakmiceService,
    private momcadService: MomcadService,
    private http: HttpClient,
    private router: Router) {
      this.filterSelectObj = [
        {
          name: 'Datum utakmice',
          columnProp: 'datumUtakmice',
          options: []
        }
      ]
    }

  ngOnInit() {
    this.pageSize = 10;
    this.pageIndex = 0;

    this.sortActive = "momcad1";
    this.sortDirection = "asc";

    this.dataSource.filterPredicate = this.createFilter();

    this.utakmiceService.getCount().subscribe(
      (count) => this.resultsLength = count
    );
    this.utakmiceService.getAll(this.pageIndex, this.pageSize, this.sortActive, this.sortDirection).subscribe(
      (data) => {
        this.utakmice = data;
        this.dataSource.data = this.utakmice;
        this.filterSelectObj.filter((o) => {
          o.options = this.getFilterObject(this.utakmice, o.columnProp);
        });
      }
    )
  }

  filterChange(filter, event) {
    this.filterValues[filter.columnProp] = event.target.value.trim().toLowerCase();
    this.dataSource.filter = JSON.stringify(this.filterValues);
  }

  getFilterObject(fullObj, key) {
    const uniqChk = [];
    fullObj.filter((obj) => {
      if (!uniqChk.includes(obj[key])) {
        uniqChk.push(obj[key]);
      }
      return obj;
    });
    return uniqChk;
  }

  createFilter() {
    let filterFunction = function (data: any, filter: string): boolean {
      let searchTerms = JSON.parse(filter);
      let isFilterSet = false;
      for (const col in searchTerms) {
        if (searchTerms[col].toString() !== '') {
          isFilterSet = true;
        } else {
          delete searchTerms[col];
        }
      }

      let nameSearch = () => {
        let found = false;
        if (isFilterSet) {
          for (const col in searchTerms) {
            searchTerms[col].trim().toLowerCase().split(' ').forEach(word => {
              if (data[col].toString().toLowerCase().indexOf(word) != -1 && isFilterSet) {
                found = true
              }
            });
          }
          return found
        } else {
          return true;
        }
      }
      return nameSearch()
    }
    return filterFunction
  }

  resetFilters() {
    this.filterValues = {}
    this.filterSelectObj.forEach((value, key) => {
      value.modelValue = undefined;
    })
    this.dataSource.filter = "";
  }

  ngAfterContentInit() {
    this.momcadService.getAllTeams().subscribe(
      (data) => {
        this.teamsCollection = data;
      }
    );
  }

  getServerData(event: PageEvent) {

    this.utakmiceService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.utakmice = data;
      }
    );
  }

  sortData(event: any) {
    this.paginator.pageIndex = 0;
    this.utakmiceService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
      (data) => {
        this.utakmice = data;
      }
    );
  }

  deleteData(id: number) {
    this.utakmiceService.delete(id).subscribe(
      response => {
        if (response) {

          this.utakmiceService.getAll(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction).subscribe(
            (data) => {
              this.utakmice = data;
            }
          );
        } else {

        }
      }
    )
  }

  editUtakmica(id: number) {
    this.router.navigate(['utakmice-edit', id]);
  }

  displayFn(momcad: Momcad): string {
    return momcad && momcad.naziv ? momcad.naziv : '';
  }

  // public applyFilter(event: Event) {
  //   console.log('utakmice ' + this.utakmice);
  //   console.log('datasource ' + this.dataSource);
  //   const filterValue = (event.target as HTMLInputElement).value;
  //   this.dataSource.filter = filterValue.trim().toLowerCase();
  // }
}
