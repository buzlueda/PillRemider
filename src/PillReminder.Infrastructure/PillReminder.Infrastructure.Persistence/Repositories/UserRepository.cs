using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, PillReminderDbContext>, IUserRepository
{
    public UserRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}