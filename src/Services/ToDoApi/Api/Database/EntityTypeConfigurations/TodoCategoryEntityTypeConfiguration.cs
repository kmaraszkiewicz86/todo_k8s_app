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

            builder.HasData(TodoCategory.All);
        }
    }
}
