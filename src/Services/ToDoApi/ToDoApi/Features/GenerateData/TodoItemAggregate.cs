using System.Collections.ObjectModel;
using AutoFixture;
using ToDoApi.Database.Entities;

namespace ToDoApi.Features.GenerateData
{
    public class TodoItemAggregate
    {
        private readonly Fixture _fixture = new ();
        private readonly List<ToDoItem> _toDoItems = [];
        public ReadOnlyCollection<ToDoItem> Items => _toDoItems.AsReadOnly();

        public TodoItemAggregate()
        {
            _fixture.Customize<ToDoItem>(c => c
                .Without(x => x.PriorityLevel)
                .Without(x => x.Category)
                .Without(x => x.Status)
                .Without(x => x.Tags)
                .With(x => x.Id, _fixture.Create<int>())
                .With(x => x.Title, _fixture.Create<string>())
                .With(x => x.IsCompleted, _fixture.Create<bool>())
                .With(x => x.CreatedAt, _fixture.Create<DateTime>())
                .With(x => x.DueDate, _fixture.Create<DateTime?>())
            );
        }

        public void GenerateRandomData(int count)
        {
            for (int i = 0; i < count; i++) 
            {
                _toDoItems.Add(GenerateToDoItem());
            }
        }

        private ToDoItem GenerateToDoItem()
        {
            Random random = new ();
            int length = random.Next(1, 6);

            ToDoItem item = _fixture.Create<ToDoItem>();

            item.Category = GenerateCategory();
            item.Status = GenerateStatus();
            item.Tags = GenerateTags(length);

            return item;
        }

        private static TodoCategory GenerateCategory()
        {
            Random random = new ();
            int index = random.Next(0, TodoCategory.All.Count - 1);

            return TodoCategory.All[index];
        }

        private static ToDoStatus GenerateStatus()
        {
            Random random = new ();
            int index = random.Next(0, ToDoStatus.All.Count - 1);

            return ToDoStatus.All[index];
        }

        private static ICollection<Tag> GenerateTags(int count)
        {
            HashSet<Tag> tags = [];

            for (var index = 0; index < count; index++)
            {
                Random random = new ();
                int tagIndex = random.Next(0, Tag.All.Count - 1);

                tags.Add(Tag.All[tagIndex]);
            }

            return tags;
        }
    }
}
