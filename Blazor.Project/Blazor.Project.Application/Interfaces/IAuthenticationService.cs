using Blazor.Project.Domain.Authentication;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Application.Interfaces;

public interface IAuthenticationService
{
    JwtToken GenerateJwtToken(User user);
}