import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TodoItemService } from '../../todo-item.service';
import { GetToDoItemCollectionResponse } from '../../todo-items-models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo-items-list',
  imports: [
    CommonModule
  ],
  templateUrl: './todo-items-list.component.html',
  styleUrls: ['./todo-items-list.component.scss']
})
export class TodoItemsListComponent {

  @Input()
  items: GetToDoItemCollectionResponse = {
    items: [],
    itemsCount: 0
  }

  constructor(
    private translate: TranslateService
  ) {
    this.translate.addLangs(['en', 'pl']);
    this.translate.setDefaultLang('en');
    this.translate.use('en');
  }
}
