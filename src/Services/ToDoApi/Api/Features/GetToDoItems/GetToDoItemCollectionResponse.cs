namespace ToDoApi.Features.GetToDoItems
{
    public record GetToDoItemCollectionResponse(
        GetToDoItemsResponse[] items,
        int ItemsCount);
}
