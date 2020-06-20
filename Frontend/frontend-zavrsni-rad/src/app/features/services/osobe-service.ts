import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Osoba } from 'src/app/modeli/osoba-model';

@Injectable()
export class OsobeService {
  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/osoba`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex: number, pageSize: number,
      sortActive: string, sortDirection: string): Observable<Array<Osoba>> {

      let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
          + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

      return this.http.get<Array<Osoba>>(url);
  }

  public getCount(): Observable<number> {
      let url = this.USER_API + "/count";
      return this.http.get<number>(url);
  }

  public getAllOsobas(): Observable<Array<Osoba>> {
    let url = 'https://localhost:44305/api/osoba'
    return this.http.get<Array<Osoba>>(url);
  }

  public get(id: number): Observable<Osoba> {
      let url = this.USER_API + '/' + id.toString();

      return this.http.get<Osoba>(url);
  }

  public add(osoba: Osoba): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.post<boolean>(this.USER_API, JSON.stringify(osoba), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
      let params = new HttpParams();
      params = params.append("id", id.toString());

      return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(osoba: Osoba): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.put<boolean>(this.USER_API, JSON.stringify(osoba), { headers: headers });

  }
}
