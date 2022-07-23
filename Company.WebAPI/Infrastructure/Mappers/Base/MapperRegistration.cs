using AutoMapper;
using System.Reflection;

namespace Company.WebAPI.Infrastructure.Mappers.Base;

/// <summary>
/// Регистрация всех классов используют AutoMapper
/// </summary>
public class MapperRegistration
{
    public static MapperConfiguration GetMapperConfiguration(Type Startup)
    {
        var profiles = GetProfiles(Startup);
        return new MapperConfiguration(config =>
        {
            // Activator.CreateInstance - Создает экземпляр указанного типа
            foreach (var profile in profiles.Select(profile => (Profile)Activator.CreateInstance(profile)!))
            {
                config.AddProfile(profile);
            }
        });
    }

    private static List<Type> GetProfiles(Type Startup)
    {
        //получаем все типы классов, которые реализуют интерфейс IAutoMapper и не являются абстрактными
        return (from t in Startup.GetTypeInfo().Assembly.GetTypes()
                where typeof(IAutoMapper).IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract
                select t).ToList();
    }
}
