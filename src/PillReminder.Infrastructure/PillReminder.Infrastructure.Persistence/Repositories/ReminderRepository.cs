using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class ReminderRepository : EfRepositoryBase<Reminder, int, PillReminderDbContext>, IReminderRepository
{
    public ReminderRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}