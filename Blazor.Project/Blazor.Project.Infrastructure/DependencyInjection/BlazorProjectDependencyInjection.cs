using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class BlazorProjectDependencyInjection
{
    public static void AddBlazorProject(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddIoCLibrary();
        services.AddIoCRepository(configurationManager);
        services.AddIoCAuthentication(configurationManager);
    }
}