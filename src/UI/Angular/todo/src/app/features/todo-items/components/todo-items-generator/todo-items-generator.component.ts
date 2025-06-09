import { Component } from '@angular/core';

@Component({
  selector: 'app-todo-items-generator',
  imports: [],
  templateUrl: './todo-items-generator.component.html',
  styleUrl: './todo-items-generator.component.scss'
})
export class TodoItemsGeneratorComponent {

  isLoading = false;

  generateTestData() {
    console.log('Generating test data...');
  }
}
