using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database.EntityTypeConfigurations
{
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
