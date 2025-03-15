using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, PillReminderDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}