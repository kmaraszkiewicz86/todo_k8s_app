using ToDoApi.Database.Entities;

namespace ToDoApi.Features.GetToDoItems
{
    public static class GetToDoItemsFactory
    {
        public static GetToDoItemCollectionResponse GenerateResponseItems(ToDoItem[] toDoItems, int itemsCount)
        {
            List<GetToDoItemsResponse> items = [];

            foreach (var toDoItem in toDoItems)
            {
                Add(toDoItem, items);
            }

            return new([.. items], itemsCount);
        }

        private static void Add(ToDoItem item, List<GetToDoItemsResponse> items)
        {
            items.Add(new GetToDoItemsResponse(
                item.Id,
                item.Title,
                item.Description,
                item.IsCompleted,
                item.DueDate,
                item.CreatedAt,
                item.UpdatedAt,
                item.PriorityLevel.Name,
                item.Category.Name,
                item.Status.Name,
                item.Tags.Select(tag => tag.Name)?.ToArray() ?? Array.Empty<string>()));
        }
    }
}
