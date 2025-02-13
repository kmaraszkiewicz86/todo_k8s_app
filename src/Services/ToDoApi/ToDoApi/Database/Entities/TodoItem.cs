namespace ToDoApi.Database.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PriorityLevelId { get; set; }
        public PriorityLevel PriorityLevel { get; set; } = null!;
        public int CategoryId { get; set; }
        public TodoCategory Category { get; set; } = null!;
        public int StatusId { get; set; }
        public ToDoStatus Status { get; set; } = null!;
        public List<Tag> Tags { get; set; } = new();
    }
}
