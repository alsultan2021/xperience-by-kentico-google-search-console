using Microsoft.Extensions.DependencyInjection;
// Add this line or correct namespace for ISearchConsoleService
using Xperience.GoogleSearchConsole.Core.Services;

namespace Xperience.GoogleSearchConsole.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGoogleSearchConsoleCore(this IServiceCollection services)
    {
        services
            // provider is auto-registered by attribute, but we need our custom service:
            .AddScoped<ISearchConsoleService, SearchConsoleService>();

        return services;
    }
}
