using Blazor.Project.WebApp.Authentication.Models;

namespace Blazor.Project.WebApp.Authentication.Services;

public interface IAuthenticationService
{
    Task<LoginOutputModel> Login(LoginInputModel loginModel);
    Task Logout();
}