using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedRoad.Common.Core.Application;

namespace SeedRoad.Template.Application;

public static class DependencyInjection
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection.AddCommonApplication(configuration, Assembly);
    }
}