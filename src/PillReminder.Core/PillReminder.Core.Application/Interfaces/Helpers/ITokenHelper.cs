using PillReminder.Core.Domain.Entities;
using CorePackages.Infrastructure.Security.Helpers.JWTHelpers;

namespace PillReminder.Core.Application.Interfaces.Helpers;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, OperationClaim operationClaim);
    RefreshToken CreateRefreshToken(User user, string ipAddress);
}