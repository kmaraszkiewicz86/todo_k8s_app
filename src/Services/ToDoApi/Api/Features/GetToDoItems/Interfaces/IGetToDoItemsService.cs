using ToDoApi.Interfaces;

namespace ToDoApi.Features.GetToDoItems.Interfaces
{
    public interface IGetToDoItemsService : IService
    {
        Task<GetToDoItemCollectionResponse> GetAllItemsAsync(GetToDoItemsQuery query);
    }
}
