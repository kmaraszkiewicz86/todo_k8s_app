using Shouldly;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Helpers;

namespace ToDoApi.Tests.Features.GenerateData.Helpers
{
    public class DataGeneratorHelperTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GenerateToDoItems_SchouldReturnEmptyArray_WhenItemsCountIsZero(int itemsLenght)
        {
            IEnumerable<ToDoItem> items = DataGeneratorHelper.GenerateToDoItems(itemsLenght);
            items.ShouldBeEmpty();
        }

        [Fact]
        public void GenerateToDoItems_SchouldReturnNotEmptyArray_WhenItemsCountGreatherThenZero()
        {
            IEnumerable<ToDoItem> items = DataGeneratorHelper.GenerateToDoItems(10);

            items.ShouldNotBeEmpty();
            items.Count().ShouldBe(10);
        }
    }
}
