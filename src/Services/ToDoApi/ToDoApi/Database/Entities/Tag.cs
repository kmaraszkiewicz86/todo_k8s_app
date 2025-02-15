namespace ToDoApi.Database.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ToDoItem> ToDoItems { get; set; } = new();

        // 🎯 Kategorie główne
        public static readonly Tag Work = new() { Id = 1, Name = "Work" };
        public static readonly Tag Personal = new() { Id = 2, Name = "Personal" };
        public static readonly Tag Family = new() { Id = 3, Name = "Family" };
        public static readonly Tag Health = new() { Id = 4, Name = "Health" };
        public static readonly Tag Finance = new() { Id = 5, Name = "Finance" };
        public static readonly Tag Education = new() { Id = 6, Name = "Education" };
        public static readonly Tag Hobby = new() { Id = 7, Name = "Hobby" };
        public static readonly Tag Fitness = new() { Id = 8, Name = "Fitness" };
        public static readonly Tag Events = new() { Id = 9, Name = "Events" };
        public static readonly Tag Shopping = new() { Id = 10, Name = "Shopping" };
        public static readonly Tag Travel = new() { Id = 11, Name = "Travel" };

        // ⏳ Priorytet i status
        public static readonly Tag Urgent = new() { Id = 12, Name = "Urgent" };
        public static readonly Tag Important = new() { Id = 13, Name = "Important" };
        public static readonly Tag LowPriority = new() { Id = 14, Name = "Low Priority" };
        public static readonly Tag FollowUp = new() { Id = 15, Name = "Follow Up" };
        public static readonly Tag Idea = new() { Id = 16, Name = "Idea" };

        // 🔧 Tagi techniczne (np. dla aplikacji IT)
        public static readonly Tag Bug = new() { Id = 17, Name = "Bug" };
        public static readonly Tag Feature = new() { Id = 18, Name = "Feature" };
        public static readonly Tag Improvement = new() { Id = 19, Name = "Improvement" };
        public static readonly Tag Refactor = new() { Id = 20, Name = "Refactor" };

        // 📋 Wszystkie tagi w kolekcji
        public static IReadOnlyList<Tag> All => new[]
        {
            Work, Personal, Family, Health, Finance, Education, Hobby, Fitness, Events, Shopping, Travel,
            Urgent, Important, LowPriority, FollowUp, Idea,
            Bug, Feature, Improvement, Refactor
        };
    }
}
