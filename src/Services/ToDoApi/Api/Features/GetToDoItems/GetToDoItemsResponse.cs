namespace ToDoApi.Features.GetToDoItems
{
    public record GetToDoItemsResponse(
        string Title,
        string? Description,
        bool IsCompleted,
        DateTime? DueDate,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string[] PriorityLevelName,
        string CategoryName,
        string Status,
        string[] Tags
    );
}
