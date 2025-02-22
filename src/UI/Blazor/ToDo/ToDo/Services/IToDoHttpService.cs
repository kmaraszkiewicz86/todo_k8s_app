using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoHttpService
    {
        Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber);
    }
}