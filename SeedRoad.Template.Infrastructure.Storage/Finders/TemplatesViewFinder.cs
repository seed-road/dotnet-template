using System.Security.Cryptography.X509Certificates;
using SeedRoad.Common.Core.Application.Extensions;
using SeedRoad.Common.Core.Application.Pagination;
using SeedRoad.Common.System;
using SeedRoad.Template.Core.Application.UsesCases.Templates;
using SeedRoad.Template.Core.Application.UsesCases.Templates.Queries;

namespace SeedRoad.Template.Infrastructure.Database.Finders;

public class TemplatesViewFinder : ITemplateViewFinder
{
    public Task<TemplateView?> GetByExamplePropertyAsync(string exampleProperty)
    {
        return new TemplateView(Guid.Empty, exampleProperty).ToTask();
    }

    public Task<TemplateView?> GetByIdAsync(Guid id)
    {
        return new TemplateView(id, "test").ToTask();
    }

    public Task<IPagedList<TemplateView>> GetPaginatedAsync(IPagination pagination)
    {
        var views = Enumerable
            .Range(0, 50)
            .Select(i => new TemplateView(Guid.NewGuid(), $"test{i}"));
        return views
            .FromPagination(pagination)
            .ToTask<IPagedList<TemplateView>>();
    }
}