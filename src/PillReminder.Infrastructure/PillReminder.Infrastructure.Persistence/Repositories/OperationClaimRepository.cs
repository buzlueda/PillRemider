using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, PillReminderDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}