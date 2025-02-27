using ToDoApi.Database.Entities;

namespace ToDoApi.Features.GenerateData.Helpers
{
    public static class DataGeneratorHelper
    {
        public static IEnumerable<ToDoItem> GenerateToDoItems(int itemLenght)
        {
            GenerateDataFactory factory = new();
            factory.GenerateRandomData(itemLenght);

            foreach (var item in factory.Items)
            {
                yield return item;
            }
        }
    }
}
