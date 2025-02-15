namespace ToDoApi.Database.Entities
{
    public class TodoCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<ToDoItem> ToDoItems { get; set; } = new();

        // 🎯 Definicja kategorii priorytetów
        public static readonly TodoCategory Work = new() { Id = 1, Name = "Work" };
        public static readonly TodoCategory Home = new() { Id = 2, Name = "Home" };
        public static readonly TodoCategory Shopping = new() { Id = 3, Name = "Shopping" };
        public static readonly TodoCategory HealthFitness = new() { Id = 4, Name = "Health & Fitness" };
        public static readonly TodoCategory PersonalDevelopment = new() { Id = 5, Name = "Personal Development" };
        public static readonly TodoCategory Events = new() { Id = 6, Name = "Events" };

        // 📋 Wszystkie wartości w kolekcji
        public static IReadOnlyList<TodoCategory> All => new[]
        {
            Work, Home, Shopping, HealthFitness, PersonalDevelopment, Events
        };
    }
}
