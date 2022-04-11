using SeedRoad.Common.Core.Application.Pagination;

namespace SeedRoad.Template.Core.Application.UsesCases.Templates.Queries;

public interface ITemplateViewFinder
{
    Task<TemplateView?> GetByExamplePropertyAsync(string exampleProperty);

    Task<TemplateView?> GetByIdAsync(Guid id);
    Task<IPagedList<TemplateView>> GetPaginatedAsync(IPagination pagination);
}