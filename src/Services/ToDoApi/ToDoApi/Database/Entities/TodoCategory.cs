namespace ToDoApi.Database.Entities
{
    public class TodoCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ToDoItem ToDoItem { get; set; }
    }
}
