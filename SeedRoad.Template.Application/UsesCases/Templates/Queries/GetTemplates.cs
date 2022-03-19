using MediatR;
using SeedRoad.Common.Core.Application.Pagination;

namespace SeedRoad.Template.Application.UsesCases.Templates.Queries;

public record GetTemplatesQuery : PaginationQueryBase<IPagedList<TemplateView>>;
public class GetTemplates: IRequestHandler<GetTemplatesQuery, IPagedList<TemplateView>>
{
    private readonly ITemplateViewFinder _templateViewFinder;

    public GetTemplates(ITemplateViewFinder templateViewFinder)
    {
        _templateViewFinder = templateViewFinder;
    }

    public Task<IPagedList<TemplateView>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        return _templateViewFinder.GetPaginatedAsync(request);
    }
}