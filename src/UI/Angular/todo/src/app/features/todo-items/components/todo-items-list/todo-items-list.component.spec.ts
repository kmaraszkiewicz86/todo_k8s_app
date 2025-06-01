import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TodoItemsListComponent } from './todo-items-list.component';
import { TodoItemService } from '../../todo-item.service';
import { of } from 'rxjs';
import { TranslateModule } from '@ngx-translate/core';
import { provideHttpClient } from '@angular/common/http';

describe('TodoItemsListComponent', () => {
  let component: TodoItemsListComponent;
  let fixture: ComponentFixture<TodoItemsListComponent>;
  let service: jasmine.SpyObj<TodoItemService>;

  beforeEach(async () => {
    const serviceSpy = jasmine.createSpyObj('TodoItemService', ['getItems']);

    await TestBed.configureTestingModule({
      imports: [
        TodoItemsListComponent,
        TranslateModule.forRoot(),
        provideHttpClient()
      ],
      providers: [
        { provide: TodoItemService, useValue: serviceSpy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(TodoItemsListComponent);
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

  it('should display "No data" when items are empty', () => {
    const mockResponse = { value: { items: [], itemsCount: 0 } };
    service.getItems.and.returnValue(of(mockResponse));

    fixture.detectChanges();

    const noData = fixture.debugElement.nativeElement.querySelector('h1');
    expect(noData.textContent).toContain('No data');
  });
});
