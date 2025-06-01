import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TodoItemService } from '../../todo-item.service';
import { GetToDoItemCollectionResponse } from '../../todo-items-models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo-items-list',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './todo-items-list.component.html',
  styleUrls: ['./todo-items-list.component.scss']
})
export class TodoItemsListComponent implements OnInit   {

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
