using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Database.Entities;

namespace ToDoApi.Database.EntityTypeConfigurations
{
    public class PriorityLevelEntityTypeConfiguration : IEntityTypeConfiguration<PriorityLevel>
    {
        public void Configure(EntityTypeBuilder<PriorityLevel> builder)
        {
            builder.ToTable("PriorityLevels");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(PriorityLevel.All);
        }
    }
}
