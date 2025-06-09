import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoItemsGeneratorComponent } from './todo-items-generator.component';

describe('TodoItemsGeneratorComponent', () => {
  let component: TodoItemsGeneratorComponent;
  let fixture: ComponentFixture<TodoItemsGeneratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TodoItemsGeneratorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TodoItemsGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
