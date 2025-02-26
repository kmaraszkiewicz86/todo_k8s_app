using Todo.Core.Models;

namespace Todo.Core.Services
{
    public interface IToDoHttpService
    {
        Task<Result> GenerateTestDataAsync(int itemCount);
        Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber);
    }
}