using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Infrastructure.Repositories;
using Blazor.Project.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class IocDependencyInjection
{
    public static void AddIoCLibrary(this IServiceCollection services)
    {   
        /*TODO: tentar substituir pelo Lamar ou StructureMap*/
        services.AddScoped<IMapperService, MapperService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRegisterUserCommand, RegisterUserCommand>();
    }
}