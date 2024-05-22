using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class BlazorProjectDependencyInjection
{
    public static void AddBlazorProject(this IServiceCollection services)
    {
        services.AddIoCLibrary();
    }
}