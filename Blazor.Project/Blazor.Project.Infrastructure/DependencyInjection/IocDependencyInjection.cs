using Lamar.Microsoft.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class IocDependencyInjection
{
    public static void AddIoCLibrary(this IHostBuilder builder)
    {
        builder.UseLamar((context, registry) =>
        {
            registry.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AssembliesFromApplicationBaseDirectory(filter => filter.FullName != null && filter.FullName.StartsWith("Blazor.Project"));       
            });
        });
    }
}