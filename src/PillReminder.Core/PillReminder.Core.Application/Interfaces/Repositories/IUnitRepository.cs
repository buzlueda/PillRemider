using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Interfaces.Repositories;

public interface IUnitRepository : IAsyncRepository<Unit, int>, IRepository<Unit, int>
{
}