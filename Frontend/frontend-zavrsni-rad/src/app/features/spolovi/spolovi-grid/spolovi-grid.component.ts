import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-spolovi-grid',
  templateUrl: './spolovi-grid.component.html',
  styleUrls: ['./spolovi-grid.component.scss']
})
export class SpoloviGridComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  columnDefs = [
    { headerName: 'ID', field: 'id', hide: true },
    { headerName: 'Naziv', field: 'naziv' },
  ];

  rowData = [
    { id: 1, naziv: 'Celica'},
    { id: 2, naziv: 'Mondeo'},
    { id: 3, naziv: 'Boxter'}
  ];
}
