using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Infrastructure.Persistence.Configs;

public class UnitConfig : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units").HasKey(x => x.Id).HasName("PK_Units");

        builder.Property(x => x.Id).HasColumnName("UnitId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Abbreviation).HasColumnName("Abbreviation").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Medications)
            .WithOne(x => x.Unit)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}