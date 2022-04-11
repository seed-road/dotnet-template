using SeedRoad.Common.Core.Domain.Definitions;
using SeedRoad.Template.Domain.Templates.DTOs;

namespace SeedRoad.Template.Domain.Templates;

public class TemplateAggregate : Aggregate<TemplateId>
{
    public string ExampleProperty { get; private set; }

    private TemplateAggregate(TemplateId id, string exampleProperty) : base(id)
    {
        ExampleProperty = exampleProperty;
    }

    public static TemplateAggregate CreateNew(Guid id, string exampleProperty)
    {
        var aggregate = new TemplateAggregate(new TemplateId(id), exampleProperty);
        aggregate.RegisterEvent(new TemplateCreatedEvent(id, exampleProperty));
        return aggregate;
    }

    public static TemplateAggregate From(TemplateReadDto templateReadDto)
    {
        return new TemplateAggregate(new TemplateId(templateReadDto.Id), templateReadDto.Property);
    }

    public TemplateWriteDto ToWriteDto()
    {
        return new TemplateWriteDto(Events) { Id = Id.Value, ExampleProperty = ExampleProperty };
    }
}