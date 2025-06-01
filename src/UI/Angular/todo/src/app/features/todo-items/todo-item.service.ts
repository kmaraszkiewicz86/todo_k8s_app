import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetToDoItemResult } from './todo-items-models';

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {

  private getTodoApiUrl = `${environment.apiUrl}/GetToDoItems`

  constructor(private http: HttpClient) { }

  generateRandomData(itemCountOnPage: number, pageNumber: number): Observable<GetToDoItemResult> {
    return this.http.get<GetToDoItemResult>(`${this.getTodoApiUrl}/${itemCountOnPage}/${pageNumber}`);
  }

  getItems(itemCountOnPage: number, pageNumber: number): Observable<GetToDoItemResult> {
    return this.http.get<GetToDoItemResult>(`${this.getTodoApiUrl}/${itemCountOnPage}/${pageNumber}`);
  }
}
