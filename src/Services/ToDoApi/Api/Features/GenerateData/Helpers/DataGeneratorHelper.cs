using ToDoApi.Database.Entities;

namespace ToDoApi.Features.GenerateData.Helpers
{
    public static class DataGeneratorHelper
    {
        public static IEnumerable<ToDoItem> GenerateToDoItems(int itemLenght)
        {
            GenerateDataAggregate aggregate = new();
            aggregate.GenerateRandomData(itemLenght);

            foreach (var item in aggregate.Items)
            {
                yield return item;
            }
        }
    }
}
