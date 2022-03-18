using FluentValidation;
using MediatR;
using SeedRoad.Template.Domain.Templates;

namespace SeedRoad.Template.Application.UsesCases;

public class TemplateCreationValidator : AbstractValidator<TemplateCreation>
{
    public TemplateCreationValidator()
    {
        RuleFor(creation => creation.ExampleValidationProperty).NotEmpty();
    }
}
public record TemplateCreation(string ExampleValidationProperty) : IRequest<Guid>;

public class CreateTemplate : IRequestHandler<TemplateCreation, Guid>
{
    private readonly ITemplates _templates;

    public CreateTemplate(ITemplates templates)
    {
        _templates = templates;
    }

    public async Task<Guid> Handle(TemplateCreation request, CancellationToken cancellationToken)
    {
        Guid id = await _templates.NextIdAsync();
        var aggregate = TemplateAggregate.CreateNew(id, request.ExampleValidationProperty);
        await _templates.SetAsync(aggregate.ToWriteDto());
        return id;
    }
}