using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Template.Infrastructure.Database.Contexts;

namespace SeedRoad.Template.Infrastructure.Database;

public static class DependencyInjection
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection InjectDatabase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddSqlServer<TemplateContext>(configuration.GetConnectionString("TemplateDb"));
    }
}