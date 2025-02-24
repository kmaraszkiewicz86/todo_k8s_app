using FluentResults;
using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoHttpService
    {
        Task<Result> GenerateTestDataAsync(int itemCount);
        Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber);
    }
}