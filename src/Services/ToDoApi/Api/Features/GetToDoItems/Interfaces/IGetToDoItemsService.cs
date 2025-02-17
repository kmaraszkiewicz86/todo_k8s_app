using ToDoApi.Interfaces;

namespace ToDoApi.Features.GetToDoItems.Interfaces
{
    public interface IGetToDoItemsService : IService
    {
        Task<GetToDoItemsResponse[]> GetAllItemsAsync(GetToDoItemsQuery query);
    }
}
