using System.Collections.ObjectModel;
using AutoFixture;
using Bogus;
using ToDoApi.Database.Entities;

namespace ToDoApi.Features.GenerateData
{
    public class GenerateDataFactory
    {
        private readonly Fixture _fixture = new ();
        private readonly Faker _faker = new();
        private readonly List<ToDoItem> _toDoItems = [];

        public ReadOnlyCollection<ToDoItem> Items => _toDoItems.AsReadOnly();

        public GenerateDataFactory()
        {
            _fixture.Customize<ToDoItem>(c => c
                .Without(x => x.Id)
                .Without(x => x.PriorityLevel)
                .Without(x => x.Category)
                .Without(x => x.Status)
                .Without(x => x.Tags)
                .With(x => x.IsCompleted, _fixture.Create<bool>())
                .With(x => x.DueDate, _fixture.Create<DateTime?>())
            );
        }

        public void GenerateRandomData(int count)
        {
            for (int i = 0; i < count; i++) 
            {
                ToDoItem item = GenerateToDoItem();
                _toDoItems.Add(item);
            }
        }

        private ToDoItem GenerateToDoItem()
        {
            Random random = new ();
            int length = random.Next(1, 6);

            ToDoItem item = _fixture.Create<ToDoItem>();

            item.Title = _faker.Lorem.Sentence(length);
            item.Description = _faker.Lorem.Paragraph(length * 5);
            item.PriorityLevel = GeneratePriorityLevel();
            item.Category = GenerateCategory();
            item.Status = GenerateStatus();
            item.Tags = GenerateTags(length);
            item.CreatedAt = DateTime.UtcNow;

            return item;
        }

        private static PriorityLevel GeneratePriorityLevel()
        {
            Random random = new();
            int index = random.Next(0, PriorityLevel.All.Count - 1);

            return PriorityLevel.All[index];
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

        private static HashSet<Tag> GenerateTags(int count)
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
