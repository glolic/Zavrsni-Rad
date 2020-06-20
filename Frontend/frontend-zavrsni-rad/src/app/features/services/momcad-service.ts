import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Momcad } from 'src/app/modeli/momcad-model';

@Injectable()
export class MomcadService {

  public API = 'https://localhost:44305/api';
  public USER_API = `${this.API}/momcad`;
  constructor(private http: HttpClient) { }

  public getAll(pageIndex: number, pageSize: number,
      sortActive: string, sortDirection: string): Observable<Array<Momcad>> {

      let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
          + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

      return this.http.get<Array<Momcad>>(url);
  }

  public getAllLocations() : Observable<Array<Momcad>>{

    let url = 'https://localhost:44305/api/momcad'

    return this.http.get<Array<Momcad>>(url);
  }

  public getCount(): Observable<number> {
      let url = this.USER_API + "/count";
      return this.http.get<number>(url);
  }

  public get(id: number): Observable<Momcad> {
      let url = this.USER_API + '/' + id.toString();

      return this.http.get<Momcad>(url);
  }

  public add(momcad: Momcad): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.post<boolean>(this.USER_API, JSON.stringify(momcad), { headers: headers });

  }
  public delete(id: number): Observable<boolean> {
      let params = new HttpParams();
      params = params.append("id", id.toString());

      return this.http.delete<boolean>(this.USER_API, { params: params });
  }
  public update(momcad: Momcad): Observable<boolean> {
      let headers = new HttpHeaders();
      headers = headers.append('Content-Type', 'application/json');

      return this.http.put<boolean>(this.USER_API, JSON.stringify(momcad), { headers: headers });

  }
}
