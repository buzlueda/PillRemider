using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Interfaces.Repositories;
public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int>
{
}