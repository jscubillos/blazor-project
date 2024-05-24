using AutoMapper;
using Blazor.Project.Application.Users.Commands.Login;
using Blazor.Project.Domain.Authentication;

namespace Blazor.Project.Infrastructure.Profiles;

public class JwtTokenProfile : Profile
{
    public JwtTokenProfile()
    {
        CreateMap<JwtToken, LoginUserOutputModel>();
    }
}