namespace Todo.Core.Models
{
    public record GetToDoItemCollectionResponse(
        GetToDoItemsResponse[] items,
        int ItemsCount);
}
