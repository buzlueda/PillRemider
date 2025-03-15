using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Interfaces.Repositories;
public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
}