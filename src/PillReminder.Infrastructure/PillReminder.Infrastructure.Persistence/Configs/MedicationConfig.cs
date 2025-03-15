using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Infrastructure.Persistence.Configs;

public class MedicationConfig : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.ToTable("Medications").HasKey(x => x.Id).HasName("PK_Medications");

        builder.Property(x => x.Id).HasColumnName("MedicationId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.Dosage).HasColumnName("Dosage").IsRequired();
        builder.Property(x => x.UnitId).HasColumnName("UnitId").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Reminders)
            .WithOne(x => x.Medication)
            .HasForeignKey(x => x.MedicationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
