using ToDoApi.Enums;

namespace ToDoApi.Models.Requests
{
    public class ToDoItemRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Category { get; set; }

        public int PriorityLevelId { get; set; }
        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.None;
        public int TodoCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string[] Tags { get; set; } = [];
    }
}
