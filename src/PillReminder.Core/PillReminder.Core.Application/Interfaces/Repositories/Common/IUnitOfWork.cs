namespace PillReminder.Core.Application.Interfaces.Repositories.Common;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IOperationClaimRepository OperationClaimRepository { get; }
    IRefreshTokenRepository RefreshTokenRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IMedicationRepository MedicationRepository { get; }
    IReminderRepository ReminderRepository { get; }
    IUnitRepository UnitRepository { get; }
}