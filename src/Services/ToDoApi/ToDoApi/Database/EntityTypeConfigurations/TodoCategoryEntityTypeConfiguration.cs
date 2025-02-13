using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database.EntityTypeConfigurations
{
    public class TodoCategoryEntityTypeConfiguration : IEntityTypeConfiguration<TodoCategory>
    {
        public void Configure(EntityTypeBuilder<TodoCategory> builder)
        {
            builder.ToTable("TodoCategories");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(
                new PriorityLevel { Id = 1, Name = "Work" },
                new PriorityLevel { Id = 2, Name = "Home" },
                new PriorityLevel { Id = 3, Name = "Shopping" },
                new PriorityLevel { Id = 4, Name = "Health & Fitness" },
                new PriorityLevel { Id = 5, Name = "Personal Development" },
                new PriorityLevel { Id = 6, Name = "Events" });
        }
    }
}
