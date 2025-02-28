using Todo.Core.Models;

namespace Todo.Core.Services
{
    public interface IToDoHttpService
    {
        Task<Result> GenerateTestDataAsync(GenerateDataRequest request);
        Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber);
    }
}