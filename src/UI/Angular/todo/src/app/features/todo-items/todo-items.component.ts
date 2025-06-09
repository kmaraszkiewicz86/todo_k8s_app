import { Component, OnInit } from '@angular/core';
import { TodoItemsListComponent } from './components/todo-items-list/todo-items-list.component';
import { TodoItemService } from './todo-item.service';
import { GetToDoItemCollectionResponse } from './todo-items-models';
import { TodoItemsGeneratorComponent } from './components/todo-items-generator/todo-items-generator.component';

@Component({
  selector: 'app-todo-items',
  standalone: true,
  imports: [
    TodoItemsListComponent,
    TodoItemsGeneratorComponent
  ],
  templateUrl: './todo-items.component.html',
  styleUrl: './todo-items.component.scss'
})
export class TodoItemsComponent implements OnInit {

  items: GetToDoItemCollectionResponse = {
    items: [],
    itemsCount: 0
  };

  constructor(
    private service: TodoItemService,
  ) { }

  ngOnInit(): void {
    this.service.getItems(50, 1).subscribe(items => {
      this.items = items.value;
    });
  }
}
