using AutoFixture;
using Shouldly;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GetToDoItems;
using ToDoApi.Tests.Fixtures;

namespace ToDoApi.Tests.Features.GetToDoItems;

public class GetToDoItemsFactoryTests
{
    private readonly GetToDoItemsFactoryFixture _fixture = new ();

    [Fact]
    public void GenerateResponseItems_ShouldReturnCorrectResponse_WhenValidToDoItemsGiven()
    {
        // Arrange
        var toDoItems = _fixture.CreateMany<ToDoItem>(5).ToArray();

        foreach (var item in toDoItems)
        {
            // AutoFixture generuje zależności dla PriorityLevel, Category, Status, Tags
            item.PriorityLevel = _fixture.Create<PriorityLevel>();
            item.Category = _fixture.Create<TodoCategory>();
            item.Status = _fixture.Create<ToDoStatus>();
            item.Tags = _fixture.CreateMany<Tag>(3).ToList();

            // Ustawienie nazw w tych zależnościach
            item.PriorityLevel.Name = _fixture.Create<string>();
            item.Category.Name = _fixture.Create<string>();
            item.Status.Name = _fixture.Create<string>();

            foreach (var tag in item.Tags)
            {
                tag.Name = _fixture.Create<string>();
            }
        }

        int expectedItemsCount = toDoItems.Length;

        // Act
        var result = GetToDoItemsFactory.GenerateResponseItems(toDoItems, expectedItemsCount);

        // Assert
        result.ItemsCount.ShouldBe(expectedItemsCount);
        result.Items.Count().ShouldBe(expectedItemsCount);

        for (int i = 0; i < expectedItemsCount; i++)
        {
            var toDoItem = toDoItems[i];
            var responseItem = result.Items[i];

            responseItem.Title.ShouldBe(toDoItem.Title);
            responseItem.Description.ShouldBe(toDoItem.Description);
            responseItem.IsCompleted.ShouldBe(toDoItem.IsCompleted);
            responseItem.DueDate.ShouldBe(toDoItem.DueDate);
            responseItem.CreatedAt.ShouldBe(toDoItem.CreatedAt);
            responseItem.UpdatedAt.ShouldBe(toDoItem.UpdatedAt);
            responseItem.PriorityLevelName.ShouldBe(toDoItem.PriorityLevel.Name);
            responseItem.CategoryName.ShouldBe(toDoItem.Category.Name);
            responseItem.Status.ShouldBe(toDoItem.Status.Name);
            responseItem.Tags.ShouldBe(toDoItem.Tags.Select(tag => tag.Name).ToArray());
        }
    }

    [Fact]
    public void GenerateResponseItems_ShouldReturnEmptyList_WhenNoToDoItemsGiven()
    {
        // Arrange
        ToDoItem[] toDoItems = System.Array.Empty<ToDoItem>();
        int expectedItemsCount = 0;

        // Act
        var result = GetToDoItemsFactory.GenerateResponseItems(toDoItems, expectedItemsCount);

        // Assert
        result.ItemsCount.ShouldBe(expectedItemsCount);
        result.Items.ShouldBeEmpty();
    }
}
