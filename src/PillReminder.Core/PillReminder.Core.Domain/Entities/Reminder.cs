using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Domain.Entities.Enums;

namespace PillReminder.Core.Domain.Entities;

public class Reminder : BaseEntity<int>
{
    public int MedicationId { get; set; }
    public virtual Medication Medication { get; set; } = null!;

    public FrequencyType FrequencyType { get; set; }  // Günlük mü, saatlik mi?
    public HashSet<TimeOfDay> TimesOfDay { get; set; } = new(); // Sabah, öğle, akşam
    public int? IntervalHours { get; set; } // X saatte bir alınacaksa (isteğe bağlı)

    public string Notes { get; set; } = string.Empty;
}
