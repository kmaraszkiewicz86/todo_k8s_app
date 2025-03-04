using Todo.Core.Models;

namespace Todo.Core.Services
{

    public class ToDoHttpService(HttpClient httpClient) : IToDoHttpService
    {
        public async Task<Result> GenerateTestDataAsync(GenerateDataRequest request)
        {
            var response = await httpClient.PostAsJsonAsync($"GenerateRandomData", request);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Fail("Someting went wrong while processing request");
            }

            return Result.Ok();
        }

        public async Task<GetToDoItemCollectionResponse> GetItemsAsync(int itemCountOnPage, int pageNumber)
        {
            Result<GetToDoItemCollectionResponse>? response = await httpClient
                .GetFromJsonAsync<Result<GetToDoItemCollectionResponse>>($"GenerateRandomData/{itemCountOnPage}/{pageNumber}");

            if (response!.IsFailed)
            {
                return new([], 0);
            }

            return response.Value;
        }
    }
}
