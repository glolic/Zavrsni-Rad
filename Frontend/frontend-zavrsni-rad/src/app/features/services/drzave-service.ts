import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Drzava } from 'src/app/modeli/drzava-model';

@Injectable()
export class DrzaveService {

  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/drzave`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex?: number, pageSize?: number,
    sortActive?: string, sortDirection?: string): Observable<Array<Drzava>> {

    let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
      + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

    return this.http.get<Array<Drzava>>(url);
  }

  public getAllCountries() : Observable<Array<Drzava>>{

    let url = 'https://localhost:44305/api/drzave'

    return this.http.get<Array<Drzava>>(url);
  }

  public getCount(): Observable<number> {
    let url = this.USER_API + "/count";
    return this.http.get<number>(url);
  }

  public get(id: number): Observable<Drzava> {
    let url = this.USER_API + '/' + id.toString();

    return this.http.get<Drzava>(url);
  }

  public add(drzava: Drzava): Observable<boolean> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    return this.http.post<boolean>(this.USER_API, JSON.stringify(drzava), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
    let params = new HttpParams();
    params = params.append("id", id.toString());

    return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(drzava: Drzava): Observable<boolean> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    return this.http.put<boolean>(this.USER_API, JSON.stringify(drzava), { headers: headers });

  }
}
