using SeedRoad.Common.Messaging.Configurations;

namespace SeedRoad.Template.Infrastructure.Messaging.Configurations;

public class RabbitMqConfiguration : Common.Messaging.Configurations.RabbitMqConfiguration
{
    public TemplateExchange TemplateExchange { get; set; }

    public RoutingConfiguration OutTemplateActionRouting =>
        new RoutingConfiguration(TemplateExchange.Name, TemplateExchange.OutTemplateActionRoutingKey);
}