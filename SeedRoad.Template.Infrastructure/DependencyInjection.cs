using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Template.Infrastructure.Database;
using SeedRoad.Template.Infrastructure.Messaging;

namespace SeedRoad.Template.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddStorage(configuration)
            .AddMessaging(configuration);
    }
}