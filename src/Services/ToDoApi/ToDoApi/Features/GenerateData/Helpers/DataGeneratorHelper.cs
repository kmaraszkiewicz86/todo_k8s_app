using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData;

namespace ToDoApi.Features.GenerateData.Helpers
{
    public static class DataGeneratorHelper
    {
        public static IEnumerable<ToDoItem> GenerateToDoItems(int itemLenght)
        {
            TodoItemAggregate aggregate = new();
            aggregate.GenerateRandomData(itemLenght);

            foreach (var item in aggregate.Items)
            {
                yield return item;
            }
        }
    }
}
