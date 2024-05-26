using Blazor.Project.WebApp.User.Models;

namespace Blazor.Project.WebApp.User.Services;

public interface IUserService
{
    Task Register(RegisterUserInputModel inputModel);
}