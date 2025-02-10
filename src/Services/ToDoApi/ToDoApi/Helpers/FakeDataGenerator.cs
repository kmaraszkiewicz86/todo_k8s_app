using AutoFixture;
using ToDoApi.Database.Entities;

namespace ToDoApi.Helpers
{
    public class FakeDataGenerator
    {
        public static IEnumerable<ToDoItem> GenerateToDoItems(int itemLenght)
        {
            for (int i = 0; i < itemLenght; i++)
                yield return GenerateToDoItem();
        }

        private static ToDoItem GenerateToDoItem()
        {
            var fixture = new Fixture();
            var item = fixture.Create<ToDoItem>();

            return item;
        }
    }
}
