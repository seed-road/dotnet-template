using MediatR;
using SeedRoad.Common.Core.Domain.Exceptions;

namespace SeedRoad.Template.Core.Application.UsesCases.Templates.Queries;

public record GetTemplateByIdQuery(Guid Id) : IRequest<TemplateView>;

public class GetTemplateById : IRequestHandler<GetTemplateByIdQuery, TemplateView>
{
    private readonly ITemplateViewFinder _templateViewFinder;

    public GetTemplateById(ITemplateViewFinder templateViewFinder)
    {
        _templateViewFinder = templateViewFinder;
    }

    public async Task<TemplateView> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        TemplateView? templateView = await _templateViewFinder.GetByIdAsync(request.Id);
        if (templateView is null)
        {
            throw new NotFoundException<Guid, TemplateView>(request.Id);
        }
        return templateView;
    }
}