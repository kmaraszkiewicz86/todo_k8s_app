namespace ToDoApi.Database.Entities
{
    public class TodoCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ToDoItem ToDoItem { get; set; } = new();
    }
}
