using SeedRoad.Common.Messaging.Configurations;

namespace SeedRoad.Template.Presentation.Messaging.Configurations;

public class RabbitMqConfiguration : Common.Messaging.Configurations.RabbitMqConfiguration
{
    public TemplateExchange TemplateExchange { get; set; }

    public RoutingConfiguration InTemplateActionRouting =>
        new(TemplateExchange.InTemplateActionRouting, TemplateExchange.Name);
}