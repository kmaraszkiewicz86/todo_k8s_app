namespace ToDoApi.Database.Entities
{
    public class ToDoStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<ToDoItem> ToDoItems { get; set; } = new();
    }
}
