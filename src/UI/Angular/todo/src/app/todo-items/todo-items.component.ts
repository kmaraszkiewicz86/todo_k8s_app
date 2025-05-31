import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TodoItemService } from '../services/todo-item.service';
import { GetToDoItemCollectionResponse } from '../models/todo-items-models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo-items',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './todo-items.component.html',
  styleUrls: ['./todo-items.component.scss']
})
export class TodoItemsComponent implements OnInit   {

  items: GetToDoItemCollectionResponse = {
    items: [],
    itemsCount: 0
  }

  constructor(
    private service: TodoItemService,
    private translate: TranslateService
  ) {
    this.translate.addLangs(['en', 'pl']);
    this.translate.setDefaultLang('en');
    this.translate.use('en');
  }

  ngOnInit(): void {
    this.service.getItems(50, 1).subscribe(items => {
      this.items = items.value;
    });
  }
}
