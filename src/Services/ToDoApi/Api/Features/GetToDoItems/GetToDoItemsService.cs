using ToDoApi.Database.Entities;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsService(IGetToDoItemsDatabaseQuery databaseQuery) : IGetToDoItemsService
    {
        public async Task<GetToDoItemCollectionResponse> GetAllItemsAsync(GetToDoItemsQuery query)
        {
            ToDoItem[] items = await databaseQuery.GetAllItemsAsync(query);
            int itemsCount = await databaseQuery.GetItemsCountAsync(query);

            return GetToDoItemsFactory.GenerateResponseItems(items, itemsCount);
        }
    }
}
