using SeedRoad.Common.Messaging.Configurations;

namespace SeedRoad.Template.Presentation.Messaging.Configurations;

public class TemplateExchange : IExchange
{
    public string Name { get; set; }
    public string InTemplateActionRouting { get; set; }
}