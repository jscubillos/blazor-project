using AutoMapper;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Application.Users.Queries.Login;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Infrastructure.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserInputModel, User>();
        
        CreateMap<User, LoginUserOutputModel>();
    }
}