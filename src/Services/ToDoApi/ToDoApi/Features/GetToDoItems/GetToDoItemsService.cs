using ToDoApi.Database.Entities;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsService(IGetToDoItemsDatabaseQuery databaseQuery) : IGetToDoItemsService
    {
        public async Task<GetToDoItemsResponse[]> GetAllItemsAsync(GetToDoItemsQuery query)
        {
            ToDoItem[] items = await databaseQuery.GetAllItemsAsync(query);

            //add mapper
            return null;
        }
    }
}
