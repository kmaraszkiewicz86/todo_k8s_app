using ToDo.Models;

namespace ToDo.Services
{

    public class ToDoHttpService(HttpClient httpClient) : IToDoHttpService
    {
        public async Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber)
        {
            var response = await httpClient.GetFromJsonAsync<Result<GetToDoItemsResponse[]>>($"GenerateRandomData/{itemCountOnPage}/{pageNumber}");

            if (response!.IsFailed)
            {
                return [];
            }

            return response.Value;
        }
    }
}
