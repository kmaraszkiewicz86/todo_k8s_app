import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetToDoItemCollectionResponse } from '../models/todo-items-models';

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {

  private getTodoApiUrl = `${environment.apiUrl}/GenerateRandomData/`

  constructor(private http: HttpClient) { }

  getItems(itemCountOnPage: number, pageNumber: number): Observable<GetToDoItemCollectionResponse> {
    return this.http.get<GetToDoItemCollectionResponse>(`${this.getTodoApiUrl}/${itemCountOnPage}/${pageNumber}`);
  }
}
