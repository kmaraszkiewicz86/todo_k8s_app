using Microsoft.EntityFrameworkCore;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database
{
    public class ToDoDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PriorityLevel> PriorityLevels { get; set; }
    }
}
