using SeedRoad.Common.Core.Domain.Events;

namespace SeedRoad.Template.Domain.Templates;

public record TemplateCreatedEvent(Guid TemplateId, string ExampleProperty) : IDomainEvent;