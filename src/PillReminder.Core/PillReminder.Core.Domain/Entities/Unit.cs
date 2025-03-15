using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Core.Domain.Entities;

public class Unit : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;

    public virtual ICollection<Medication> Medications { get; set; } = new HashSet<Medication>();
}
