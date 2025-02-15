namespace ToDoApi.Database.Entities
{
    public class ToDoStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        List<ToDoItem> ToDoItems { get; set; } = new();

        // 🎯 Definicja statusów
        public static readonly ToDoStatus New = new() { Id = 1, Name = "New" };
        public static readonly ToDoStatus InProgress = new() { Id = 2, Name = "In Progress" };
        public static readonly ToDoStatus Completed = new() { Id = 3, Name = "Completed" };
        public static readonly ToDoStatus Canceled = new() { Id = 4, Name = "Canceled" };

        // 📋 Wszystkie wartości w kolekcji
        public static IReadOnlyList<ToDoStatus> All => new[]
        {
            New, InProgress, Completed, Canceled
        };
    }
}
