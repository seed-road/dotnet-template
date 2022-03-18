using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Common.Configuration;
using SeedRoad.Common.Infrastructure.Messaging.Extensions;
using SeedRoad.Template.Domain.Templates;
using SeedRoad.Template.Infrastructure.Messaging.Configurations;

namespace SeedRoad.Template.Infrastructure.Messaging;

public static class DependencyInjection
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection InjectMessaging(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var rabbitMqConfig = configuration.GetRequiredConfiguration<RabbitMqConfiguration>();
        return serviceCollection
            .AddCommonDispatchService(rabbitMqConfig)
            .AddCommonDispatcher<TemplateCreatedEvent>(rabbitMqConfig.OutTemplateActionRouting);
    }
}