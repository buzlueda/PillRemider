using PillReminder.Core.Application.Interfaces.Helpers;
using PillReminder.Core.Application.Interfaces.Repositories.Common;
using PillReminder.Core.Application.Interfaces.Services;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Services.RefreshTokenService;

public class RefreshTokenManager(IUnitOfWork unitOfWork, ITokenHelper tokenHelper) : IRefreshTokenService
{
    public async Task AddRefreshToken(RefreshToken refreshToken)
    {
        await unitOfWork.RefreshTokenRepository.AddAsync(refreshToken);
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task DeleteOldRefreshTokens(Guid userId, int refreshTokenTTL)
    {
        var refreshTokens = await unitOfWork.RefreshTokenRepository.GetListAsync(
            predicate: r => r.UserId == userId && r.RevokedDate == null && r.ExpirationDate >= DateTime.UtcNow && r.CreatedAt.AddDays(refreshTokenTTL) <= DateTime.UtcNow
        );
        var refreshTokensList = refreshTokens.Items.ToList();
        await unitOfWork.RefreshTokenRepository.DeleteRangeAsync(refreshTokensList);
    }

    public async Task<RefreshToken?> GetRefreshTokenByToken(string? token)
    {
        return await unitOfWork.RefreshTokenRepository.GetAsync(predicate: r => r.Token == token);
    }
}