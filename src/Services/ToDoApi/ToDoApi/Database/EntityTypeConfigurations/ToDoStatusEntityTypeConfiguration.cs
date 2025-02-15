using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database.EntityTypeConfigurations
{
    public class ToDoStatusEntityTypeConfiguration : IEntityTypeConfiguration<ToDoStatus>
    {
        public void Configure(EntityTypeBuilder<ToDoStatus> builder)
        {
            builder.ToTable("ToDoStatuses");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(ToDoStatus.All);
        }
    }
}
