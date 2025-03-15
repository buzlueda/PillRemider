using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Core.Domain.Entities;
public class Category : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Medication> Medications { get; set; } = new HashSet<Medication>();
}