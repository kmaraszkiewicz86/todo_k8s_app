using ToDo.Models;

namespace ToDo.Services
{
    public class ToDoHttpService(HttpClient httpClient) : IToDoHttpService
    {
        public async Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber)
        {
            return await httpClient.GetFromJsonAsync<GetToDoItemsResponse[]>($"GenerateRandomData/{itemCountOnPage}/{pageNumber}")
                   ?? [];
        }
    }
}
