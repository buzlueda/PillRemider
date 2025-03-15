using CorePackages.Infrastructure.Persistence.Repositories.Common;
using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Domain.Entities;
using PillReminder.Infrastructure.Persistence.Contexts;

namespace PillReminder.Infrastructure.Persistence.Repositories;

public class CategoryRepository  : EfRepositoryBase<Category, int, PillReminderDbContext>, ICategoryRepository
{
    public CategoryRepository(PillReminderDbContext dbContext) : base(dbContext)
    {
    }
}