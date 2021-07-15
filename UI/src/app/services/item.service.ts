import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../models/item';
import { ApiService } from './api-service';

@Injectable({
  providedIn: 'root'
})
export class ItemService extends ApiService<Item> {

  constructor(_http: HttpClient) { 
    super("https://localhost:5001/item", _http);
  }

  public create(listId: number, name: string ): Observable<Item>
  {
    return this._http.post<Item>(this._baseUrl, {listId: listId, name: name})
  }

  public update(id: number, name: string, isChecked: boolean|undefined)
  {
    return this._http.put<Item>(this._baseUrl + "/" + id, {name: name, isChecked: isChecked});
  }

}
