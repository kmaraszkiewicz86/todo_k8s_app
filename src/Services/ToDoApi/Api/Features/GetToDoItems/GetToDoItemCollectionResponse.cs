namespace ToDoApi.Features.GetToDoItems
{
    public record GetToDoItemCollectionResponse(
        GetToDoItemsResponse[] Items,
        int ItemsCount);
}
