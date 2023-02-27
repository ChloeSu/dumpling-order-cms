import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Item } from '../models/item';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private _baseUrl = 'items';
  public item?: Item;


  constructor(
    private http: HttpClient
    ) { }

  getItems (): Observable<Item[]> {
    return this.http.get<Item[]>(this._baseUrl)
  }

  addItem (item: Item): Observable<any> {
    return this.http.post(this._baseUrl, item, httpOptions);
  }

  updateItem (item: Item): Observable<any> {
    return this.http.put(this._baseUrl, item, httpOptions);
  }

  deleteItem (id: string): Observable<any> {
    return this.http.delete(`${this._baseUrl}/${id}`, httpOptions);
  }
}
