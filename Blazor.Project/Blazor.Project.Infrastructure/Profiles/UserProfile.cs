using AutoMapper;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserInputModel, User>();
    }
}