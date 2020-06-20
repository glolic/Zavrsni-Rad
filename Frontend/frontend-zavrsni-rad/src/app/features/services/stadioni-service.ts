import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Stadion } from 'src/app/modeli/stadion-model';

@Injectable()
export class StadioniService {

  public API = 'https://localhost:44305/api';
    public USER_API = `${this.API}/stadion`;
    constructor(private http: HttpClient) { }

    public getAll(pageIndex: number, pageSize: number,
        sortActive: string, sortDirection: string): Observable<Array<Stadion>> {

        let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
            + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

        return this.http.get<Array<Stadion>>(url);
    }

    public getAllStadiums() : Observable<Array<Stadion>>{

      let url = 'https://localhost:44305/api/stadion'
  
      return this.http.get<Array<Stadion>>(url);
    }

    public getCount(): Observable<number> {
        let url = this.USER_API + "/count";
        return this.http.get<number>(url);
    }

    public get(id: number): Observable<Stadion> {
        let url = this.USER_API + '/' + id.toString();

        return this.http.get<Stadion>(url);
    }

    public add(stadion: Stadion): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.post<boolean>(this.USER_API, JSON.stringify(stadion), { headers: headers });

    }
    public delete(id: number): Observable<boolean> {
        let params = new HttpParams();
        params = params.append("id", id.toString());

        return this.http.delete<boolean>(this.USER_API, { params: params });
    }
    public update(stadion: Stadion): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.put<boolean>(this.USER_API, JSON.stringify(stadion), { headers: headers });

    }
}
