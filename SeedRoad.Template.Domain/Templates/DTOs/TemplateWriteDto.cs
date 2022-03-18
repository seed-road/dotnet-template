using SeedRoad.Common.Core.Domain.Definitions;
using SeedRoad.Common.Core.Domain.Events;

namespace SeedRoad.Template.Domain.Templates.DTOs;

public class TemplateWriteDto : WriteAggregateDto
{
    public TemplateWriteDto(IEnumerable<IDomainEvent> events) : base(events)
    {
    }

    public Guid Id { get; set; }
    public string ExampleProperty { get; set; }
}