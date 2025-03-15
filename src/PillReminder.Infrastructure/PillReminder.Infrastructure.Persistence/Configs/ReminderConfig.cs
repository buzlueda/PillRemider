using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Infrastructure.Persistence.Configs;
public class ReminderConfig : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.ToTable("Reminders").HasKey(x => x.Id).HasName("PK_Reminders");

        builder.Property(x => x.Id).HasColumnName("ReminderId");
        builder.Property(x => x.MedicationId).HasColumnName("MedicationId").IsRequired();
        builder.Property(x => x.FrequencyType).HasColumnName("FrequencyType").IsRequired();
        builder.Property(x => x.TimesOfDay).HasColumnName("TimesOfDay").IsRequired();
        builder.Property(x => x.IntervalHours).HasColumnName("IntervalHours");
        builder.Property(x => x.Notes).HasColumnName("Notes");

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
    }
}