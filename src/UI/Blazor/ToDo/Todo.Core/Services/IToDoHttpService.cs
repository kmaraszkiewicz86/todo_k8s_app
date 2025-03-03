using Todo.Core.Models;

namespace Todo.Core.Services
{
    public interface IToDoHttpService
    {
        Task<Result> GenerateTestDataAsync(GenerateDataRequest request);
        Task<GetToDoItemCollectionResponse> GetItemsAsync(int itemCountOnPage, int pageNumber);
    }
}