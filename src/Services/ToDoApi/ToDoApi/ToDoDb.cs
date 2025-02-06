using Microsoft.EntityFrameworkCore;

namespace ToDoApi
{
    public class ToDoDb(DbContextOptions<ToDoDb> options): DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
