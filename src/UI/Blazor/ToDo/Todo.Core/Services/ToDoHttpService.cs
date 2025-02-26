using Todo.Core.Models;

namespace Todo.Core.Services
{

    public class ToDoHttpService(HttpClient httpClient) : IToDoHttpService
    {
        public async Task<Result> GenerateTestDataAsync(int itemCount)
        {
            GenerateDataRequest request = new(itemCount);
            var response = await httpClient.PostAsJsonAsync($"GenerateRandomData", request);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail("Someting went wrong while processing request");
            }

            return Result.Ok();
        }

        public async Task<GetToDoItemsResponse[]> GetItemsAsync(int itemCountOnPage, int pageNumber)
        {
            Result<GetToDoItemsResponse[]>? response = await httpClient
                .GetFromJsonAsync<Result<GetToDoItemsResponse[]>>($"GenerateRandomData/{itemCountOnPage}/{pageNumber}");

            if (response!.IsFailed)
            {
                return [];
            }

            return response.Value;
        }
    }
}
