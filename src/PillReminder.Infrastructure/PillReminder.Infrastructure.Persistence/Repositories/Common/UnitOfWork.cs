using PillReminder.Core.Application.Interfaces.Repositories;
using PillReminder.Core.Application.Interfaces.Repositories.Common;
using PillReminder.Infrastructure.Persistence.Contexts;

namespace PillReminder.Infrastructure.Persistence.Repositories.Common;
public class UnitOfWork : IUnitOfWork
{
    private readonly PillReminderDbContext _dbContext;
    public UnitOfWork(PillReminderDbContext dbContext)
    {
        _dbContext = dbContext;
        OperationClaimRepository = new OperationClaimRepository(_dbContext);
        RefreshTokenRepository = new RefreshTokenRepository(_dbContext);
        UserRepository = new UserRepository(_dbContext);
        CategoryRepository = new CategoryRepository(_dbContext);
        MedicationRepository = new MedicationRepository(_dbContext);
        ReminderRepository = new ReminderRepository(_dbContext);
        UnitRepository = new UnitRepository(_dbContext);
    }
    public IUserRepository UserRepository { get; private set; }

    public IOperationClaimRepository OperationClaimRepository { get; private set; }

    public IRefreshTokenRepository RefreshTokenRepository { get; private set; }

    public ICategoryRepository CategoryRepository { get; private set; }

    public IMedicationRepository MedicationRepository { get; private set; }

    public IReminderRepository ReminderRepository { get; private set; }

    public IUnitRepository UnitRepository { get; private set; }
}