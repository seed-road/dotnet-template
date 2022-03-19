using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Common.Configuration;
using SeedRoad.Common.Presentation.Messaging.Extensions;
using SeedRoad.Template.Application.UsesCases;
using SeedRoad.Template.Application.UsesCases.Templates;
using SeedRoad.Template.Application.UsesCases.Templates.Commands;
using SeedRoad.Template.Presentation.Messaging.Configurations;

namespace SeedRoad.Template.Presentation.Messaging;

public static class DependencyInjection
{
    public static IServiceCollection AddMessaging(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var rabbitMqConfiguration = configuration.GetRequiredConfiguration<RabbitMqConfiguration>();
        return serviceCollection
            .AddCommonListener<TemplateCreation>(rabbitMqConfiguration, rabbitMqConfiguration.InTemplateActionRouting);
    }
}