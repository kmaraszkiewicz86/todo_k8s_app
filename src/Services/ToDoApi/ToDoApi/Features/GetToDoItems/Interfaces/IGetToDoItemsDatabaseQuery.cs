using ToDoApi.Database.Entities;
using ToDoApi.Interfaces;

namespace ToDoApi.Features.GetToDoItems.Interfaces
{
    public interface IGetToDoItemsDatabaseQuery : IQuery
    {
        Task<ToDoItem[]> GetAllItemsAsync(GetToDoItemsQuery query);
    }
}
