namespace ToDoApi.Database.Entities
{
    public class PriorityLevel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ToDoItem> ToDoItems { get; set; } = new();

        // 🎯 Definicja poziomów priorytetu
        public static readonly PriorityLevel Low = new() { Id = 1, Name = "Low" };
        public static readonly PriorityLevel Medium = new() { Id = 2, Name = "Medium" };
        public static readonly PriorityLevel High = new() { Id = 3, Name = "High" };

        // 📋 Wszystkie wartości w kolekcji
        public static IReadOnlyList<PriorityLevel> All => new[]
        {
            Low, Medium, High
        };
    }
}
