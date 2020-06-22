import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Utakmica } from 'src/app/modeli/utakmica-model';

@Injectable()
export class UtakmiceService {
  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/utakmice`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex: number, pageSize: number,
      sortActive: string, sortDirection: string): Observable<Array<Utakmica>> {

      let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
          + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

      return this.http.get<Array<Utakmica>>(url);
  }

  public getCount(): Observable<number> {
      let url = this.USER_API + "/count";
      return this.http.get<number>(url);
  }

  public getAllUtakmice(): Observable<Array<Utakmica>> {
    let url = 'https://localhost:44305/api/utakmice'
    return this.http.get<Array<Utakmica>>(url);
  }

  public get(id: number): Observable<Utakmica> {
      let url = this.USER_API + '/' + id.toString();

      return this.http.get<Utakmica>(url);
  }

  public add(utakmice: Utakmica): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.post<boolean>(this.USER_API, JSON.stringify(utakmice), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
      let params = new HttpParams();
      params = params.append("id", id.toString());

      return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(utakmice: Utakmica): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.put<boolean>(this.USER_API, JSON.stringify(utakmice), { headers: headers });

  }
}
