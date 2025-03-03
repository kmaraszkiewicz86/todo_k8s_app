namespace Todo.Core.Models
{
    public record GetToDoItemCollectionResponse(
        GetToDoItemsResponse[] Items,
        int ItemsCount);
}
