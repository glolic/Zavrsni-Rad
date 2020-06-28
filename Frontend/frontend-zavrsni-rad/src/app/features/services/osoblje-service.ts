import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Osoblje } from 'src/app/modeli/osoblje-model';

@Injectable()
export class OsobljeService {
  public API = 'https://localhost:44305/api';
    public USER_API = `${this.API}/osoblje`;
    constructor(private http: HttpClient) { }

    public getAll(pageIndex: number, pageSize: number,
        sortActive: string, sortDirection: string): Observable<Array<Osoblje>> {

        let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
            + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

        return this.http.get<Array<Osoblje>>(url);
    }

    public getAllStaff() : Observable<Array<Osoblje>> {
        let url = 'https://localhost:44305/api/osoblje'
        return this.http.get<Array<Osoblje>>(url);
    }

    public getAllStaffFromTeam(id: number): Observable<Array<Osoblje>> {
        let url = 'https://localhost:44305/api/osoblje/allFromTeam?id=' + id;
        return this.http.get<Array<Osoblje>>(url);
    }

    public getCount(): Observable<number> {
        let url = this.USER_API + "/count";
        return this.http.get<number>(url);
    }

    public get(id: number): Observable<Osoblje> {
        let url = this.USER_API + '/' + id.toString();

        return this.http.get<Osoblje>(url);
    }

    public add(osoblje: Osoblje): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.post<boolean>(this.USER_API, JSON.stringify(osoblje), { headers: headers });

    }
    public delete(id: number): Observable<boolean> {
        let params = new HttpParams();
        params = params.append("id", id.toString());

        return this.http.delete<boolean>(this.USER_API, { params: params });
    }
    public update(osoblje: Osoblje): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.put<boolean>(this.USER_API, JSON.stringify(osoblje), { headers: headers });

    }
}
