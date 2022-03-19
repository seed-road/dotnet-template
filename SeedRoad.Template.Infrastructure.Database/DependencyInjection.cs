using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Common.Core.Application;
using SeedRoad.Common.Core.Application.Events;
using SeedRoad.Template.Application.UsesCases.Templates.Queries;
using SeedRoad.Template.Domain.Templates;
using SeedRoad.Template.Infrastructure.Database.Contexts;
using SeedRoad.Template.Infrastructure.Database.Finders;
using SeedRoad.Template.Infrastructure.Database.Repositories;

namespace SeedRoad.Template.Infrastructure.Database;

public static class DependencyInjection
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection InjectDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        Type interceptorType = typeof(EventPublisherInterceptor);
        return serviceCollection
            .AddSqlServer<TemplateContext>(configuration.GetConnectionString("TemplateDb"))
            .AddProxyScoped<ITemplates, TemplatesRepository>(interceptorType)
            .AddScoped<ITemplateViewFinder, TemplatesViewFinder>();
    }
}