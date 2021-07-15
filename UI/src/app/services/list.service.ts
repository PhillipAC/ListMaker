import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { List } from '../models/list';
import { ApiService } from './api-service';

@Injectable({
  providedIn: 'root'
})
export class ListService extends ApiService<List> {

  constructor(_http: HttpClient) { 
    super("https://localhost:5001/list", _http);
  }

  public create(name: string, description: string ): Observable<List>
  {
    return this._http.post<List>(this._baseUrl, {name: name, description: description})
  }

  public update(id: number, name: string, description: string ): Observable<List>
  {
    return this._http.put<List>(this._baseUrl + "/" + id, {name: name, description: description});
  }
}
