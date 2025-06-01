import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TodoItemsListComponent } from './todo-items-list.component';
import { TodoItemService } from '../../todo-item.service';
import { TranslateModule } from '@ngx-translate/core';

describe('TodoItemsListComponent', () => {
  let component: TodoItemsListComponent;
  let fixture: ComponentFixture<TodoItemsListComponent>;

  beforeEach(async () => {
    const serviceSpy = jasmine.createSpyObj('TodoItemService', ['getItems']);

    await TestBed.configureTestingModule({
      imports: [
        TodoItemsListComponent,
        TranslateModule.forRoot()
      ],
      providers: [
        { provide: TodoItemService, useValue: serviceSpy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(TodoItemsListComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should generate li elementes after passed not null data to input attribute', () => {
    const mockResponse = {
      items: [
        {
          title: 'Task 1',
          isCompleted: false,
          createdAt: new Date(),
          priorityLevelName: 'High',
          categoryName: 'Work',
          status: 'Pending',
          tags: [],
        },
        {
          title: 'Task 2',
          isCompleted: true,
          createdAt: new Date(),
          priorityLevelName: 'Low',
          categoryName: 'Personal',
          status: 'Done',
          tags: ['urgent'],
        }
      ],
      itemsCount: 2
    };

    component.items = mockResponse;

    fixture.detectChanges();

    const liElement = fixture.debugElement.nativeElement.querySelector('ul');
    const liElements = liElement.querySelectorAll('li');

    console.log(liElement);

    expect(liElements.length).toBe(2);
    expect(liElements[0].textContent).toContain('Task 1');
  });

  it('should generate empty html element after passed not null data to input attribute', () => {
    const mockResponse = { items: [], itemsCount: 0 };
    component.items = mockResponse;

    fixture.detectChanges();

    const noData = fixture.debugElement.nativeElement.querySelector('h1');
    expect(noData.textContent).toContain('No data');
  });
});
