using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class MedicationRepository : EfRepositoryBase<Medication, int, PillReminderDbContext>, IMedicationRepository
{
    public MedicationRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}