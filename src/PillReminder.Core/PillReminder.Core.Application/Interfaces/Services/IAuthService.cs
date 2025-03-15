using PillReminder.Core.Application.Features.Auth.Commands.Login;
using PillReminder.Core.Application.Features.Auth.Commands.Register;
using PillReminder.Core.Application.Features.Auth.Models;

namespace PillReminder.Core.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoggedResponse> LoginAsync(LoginModel loginModel);
    Task<RegisteredResponse> RegisterAsync(RegisterModel registerModel);
}