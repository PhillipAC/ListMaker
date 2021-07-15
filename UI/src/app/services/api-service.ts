import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export class ApiService<T> {
    constructor(
        protected _baseUrl: string,
        protected _http: HttpClient
    ){}

    getById(id: number): Observable<T>{
        return this._http.get<T>(this._baseUrl + "/" + id)
    }

    getAll(): Observable<T[]>{
        return this._http.get<T[]>(this._baseUrl);
    }

    deleteById(id: number): Observable<Object>{
        return this._http.delete(this._baseUrl + "/" + id);
    }
}
