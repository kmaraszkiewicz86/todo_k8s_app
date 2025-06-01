import { Component } from '@angular/core';
import { TodoItemsListComponent } from './components/todo-items-list/todo-items-list.component';

@Component({
  selector: 'app-todo-items',
  imports: [
    TodoItemsListComponent
  ],
  templateUrl: './todo-items.component.html',
  styleUrl: './todo-items.component.scss'
})
export class TodoItemsComponent {

}
