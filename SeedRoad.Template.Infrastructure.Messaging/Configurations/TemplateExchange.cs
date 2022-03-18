using SeedRoad.Common.Messaging.Configurations;

namespace SeedRoad.Template.Infrastructure.Messaging.Configurations;

public class TemplateExchange : IExchange
{
    public string Name { get; set; }
    public string OutTemplateActionRoutingKey { get; set; }
}