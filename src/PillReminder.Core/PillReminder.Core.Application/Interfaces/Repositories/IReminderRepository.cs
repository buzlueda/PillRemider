using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Interfaces.Repositories;

public interface IReminderRepository : IAsyncRepository<Reminder, int>, IRepository<Reminder, int>
{
}