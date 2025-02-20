using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database.EntityTypeConfigurations
{
    public class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("TodoItems");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Title)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnType("nvarchar(MAX)");

            builder.Property(u => u.IsCompleted)
                .IsRequired();

            builder.Property(u => u.PriorityLevelId)
                .IsRequired();

            builder.Property(u => u.CategoryId)
                .IsRequired();

            builder.Property(u => u.StatusId)
                .IsRequired();

        }
    }
}
