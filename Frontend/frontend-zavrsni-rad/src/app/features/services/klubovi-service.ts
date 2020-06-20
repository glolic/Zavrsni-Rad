import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Klub } from 'src/app/modeli/klub-model';

@Injectable()
export class KluboviService {

  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/klub`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex: number, pageSize: number,
      sortActive: string, sortDirection: string): Observable<Array<Klub>> {

      let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
          + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

      return this.http.get<Array<Klub>>(url);
  }

  public getCount(): Observable<number> {
      let url = this.USER_API + "/count";
      return this.http.get<number>(url);
  }

  public get(id: number): Observable<Klub> {
      let url = this.USER_API + '/' + id.toString();

      return this.http.get<Klub>(url);
  }

  public add(klub: Klub): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.post<boolean>(this.USER_API, JSON.stringify(klub), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
      let params = new HttpParams();
      params = params.append("id", id.toString());

      return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(klub: Klub): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.put<boolean>(this.USER_API, JSON.stringify(klub), { headers: headers });

  }
}
