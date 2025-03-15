using AutoMapper;
using PillReminder.Core.Application.Features.Auth.Commands.Login;
using PillReminder.Core.Application.Features.Auth.Commands.Register;
using PillReminder.Core.Application.Features.Auth.Models;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Core.Application.Services.UserService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, RegisterModel>().ReverseMap();
        CreateMap<User, RegisteredResponse>().ReverseMap();

        CreateMap<User, LoggedResponse>().ReverseMap();
    }
}