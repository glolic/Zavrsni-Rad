import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pozicija } from 'src/app/modeli/pozicija-model';

@Injectable()
export class PozicijeService {

  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/pozicije`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex: number, pageSize: number,
    sortActive: string, sortDirection: string): Observable<Array<Pozicija>> {

    let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
      + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

    return this.http.get<Array<Pozicija>>(url);
  }

  public getAllPositions(): Observable<Array<Pozicija>> {
    let url = 'https://localhost:44305/api/pozicije'
    return this.http.get<Array<Pozicija>>(url);
  }

  public getCount(): Observable<number> {
    let url = this.USER_API + "/count";
    return this.http.get<number>(url);
  }

  public get(id: number): Observable<Pozicija> {
    let url = this.USER_API + '/' + id.toString();

    return this.http.get<Pozicija>(url);
  }

  public add(pozicija: Pozicija): Observable<boolean> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    return this.http.post<boolean>(this.USER_API, JSON.stringify(pozicija), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
    let params = new HttpParams();
    params = params.append("id", id.toString());

    return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(pozicija: Pozicija): Observable<boolean> {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');

    return this.http.put<boolean>(this.USER_API, JSON.stringify(pozicija), { headers: headers });

  }
}
