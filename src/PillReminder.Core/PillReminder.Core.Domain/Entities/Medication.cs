using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Core.Domain.Entities;

public class Medication : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public decimal Dosage { get; set; } // Kaç doz alınacak
    public int UnitId { get; set; }  // Ölçü birimi
    public virtual Unit Unit { get; set; } = null!;
    
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public bool IsActive { get; set; }
    
    public virtual ICollection<Reminder> Reminders { get; set; } = new HashSet<Reminder>();
}
