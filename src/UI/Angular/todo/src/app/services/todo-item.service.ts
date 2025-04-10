import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export interface GetToDoItemsResponse {
  title: string,
  description?: string,
  isCompleted: boolean,
  dueDate?: Date,
  createdAt: Date,
  updatedAt?: Date,
  priorityLevelName: string,
  categoryName: string,
  status: string,
  tags: string[]
}

export interface GetToDoItemCollectionResponse {
  items: GetToDoItemsResponse[],
  itemsCount: number
}

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
