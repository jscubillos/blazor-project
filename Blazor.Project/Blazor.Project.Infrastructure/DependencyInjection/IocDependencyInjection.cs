using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Application.Users.Queries.Login;
using Blazor.Project.Domain.Company;
using Blazor.Project.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class IocDependencyInjection
{
    public static void AddIoCLibrary(this IServiceCollection services)
    {   
        /*TODO: tentar substituir pelo Lamar ou StructureMap*/
        
        //Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IMapperService, MapperService>();
        services.AddScoped<IPasswordService, PasswordService>();
        
        //Application
        services.AddScoped<IRegisterUserCommand, RegisterUserCommand>();
        services.AddScoped<ILoginUserQuery, LoginUserQuery>();
        services.AddScoped<IRegisterSpecialityCommand, RegisterSpecialityCommand>();
    }
}