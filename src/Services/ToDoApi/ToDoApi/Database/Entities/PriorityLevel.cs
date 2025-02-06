namespace ToDoApi.Database.Entities
{
    public class PriorityLevel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ToDoItem> ToDoItems { get; set; } = new();
    }
}
