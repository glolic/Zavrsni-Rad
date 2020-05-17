import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Spol } from 'src/app/modeli/spol-model';

@Injectable()
export class SpoloviService {
    public API = 'https://localhost:44305/api';
    public USER_API = `${this.API}/spol`;
    constructor(private http: HttpClient) { }

    public getAll(pageIndex: number, pageSize: number,
        sortActive: string, sortDirection: string): Observable<Array<Spol>> {

        let url = this.USER_API + "?pageSize=" + pageSize.toString() + "&pageIndex=" + pageIndex.toString()
            + "&sortColumn=" + sortActive + "&sortOrder=" + sortDirection;

        return this.http.get<Array<Spol>>(url);
    }

    public getCount(): Observable<number> {
        let url = this.USER_API + "/count";
        return this.http.get<number>(url);
    }

    public get(id: number): Observable<Spol> {
        let url = this.USER_API + '/' + id.toString();

        return this.http.get<Spol>(url);
    }

    public add(spol: Spol): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.post<boolean>(this.USER_API, JSON.stringify(spol), { headers: headers });

    }
    public delete(id: number): Observable<boolean> {
        let params = new HttpParams();
        params = params.append("id", id.toString());

        return this.http.delete<boolean>(this.USER_API, { params: params });
    }
    public update(spol: Spol): Observable<boolean> {
        let headers = new HttpHeaders();
        headers = headers.append('Content-Type', 'application/json');

        return this.http.put<boolean>(this.USER_API, JSON.stringify(spol), { headers: headers });

    }
}