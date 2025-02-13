using System;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Database.Entities;
using ToDoApi.Database.EntityTypeConfigurations;

namespace ToDoApi.Database
{
    public class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }
        public DbSet<ToDoStatus> ToDoStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PriorityLevel> PriorityLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var applyGenericMethod = typeof(ModelBuilder)
                .GetMethods()
                .First(m => m.Name == nameof(ModelBuilder.ApplyConfiguration) &&
                            m.GetParameters().FirstOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            var configurations = typeof(ToDoDbContext).Assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .Select(Activator.CreateInstance);

            foreach (var config in configurations)
            {
                var entityType = config!.GetType().GetInterfaces().First().GetGenericArguments().First();
                var applyMethod = applyGenericMethod.MakeGenericMethod(entityType);
                applyMethod.Invoke(modelBuilder, new[] { config });
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
