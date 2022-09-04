using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Company.Base.Infractructure.Repository;

/// <summary>
/// Dependency Injection Registration
/// </summary>
public static class RepositoriesDependencyContainer
{
    /// <summary>
    /// Registration Repositories
    /// </summary>
    /// <param name="services">Контракт для коллекции дескрипторов служб</param>
    /// <returns>Контракт для коллекции дескрипторов служб</returns>
    public static IServiceCollection AddRepositoriesConfigureServices(this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsAbstract);
        foreach (var type in types)
        {
            foreach (var i in type.GetInterfaces())
            {
                if (!i.IsGenericType || i.GetGenericTypeDefinition() != typeof(IBaseRepository<,>)) continue;

                var interfaceType = typeof(IBaseRepository<,>).MakeGenericType(i.GetGenericArguments());
                services.AddTransient(interfaceType, type);
            }
        }

        return services;
    }
}