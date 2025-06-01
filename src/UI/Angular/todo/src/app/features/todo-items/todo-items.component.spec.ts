import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TodoItemsComponent } from './todo-items.component';
import { TodoItemService } from './todo-item.service';
import { of } from 'rxjs';
import { TranslateModule } from '@ngx-translate/core';
import { provideHttpClient } from '@angular/common/http';

describe('TodoItemsListComponent', () => {
  let component: TodoItemsComponent;
  let fixture: ComponentFixture<TodoItemsComponent>;
  let service: jasmine.SpyObj<TodoItemService>;

  beforeEach(async () => {
    const serviceSpy = jasmine.createSpyObj('TodoItemService', ['getItems']);

    await TestBed.configureTestingModule({
      imports: [
        TodoItemsComponent,
        TranslateModule.forRoot()
      ],
      providers: [
        provideHttpClient(),
        { provide: TodoItemService, useValue: serviceSpy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(TodoItemsComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(TodoItemService) as jasmine.SpyObj<TodoItemService>;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should load items on init', () => {
    const mockResponse = {
      value: {
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
      }
    };

    service.getItems.and.returnValue(of(mockResponse));

    fixture.detectChanges();

    expect(component.items.items.length).toBe(2);
    expect(component.items.items[0].title).toBe('Task 1');
    expect(service.getItems).toHaveBeenCalledWith(50, 1);
  });

  it('should display be empty collection when service returned no data', () => {
    const mockResponse = { value: { items: [], itemsCount: 0 } };
    service.getItems.and.returnValue(of(mockResponse));

    fixture.detectChanges();

    expect(component.items.items.length).toBe(0);
  });
});
