using AutoMapper;
using Company.Base.Infractructure.Repository;
using Company.Parser.Controllers.FactoryController;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Extensions.HtmlLoader;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.Managers;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.Infrastructure.Mappers;
using Company.Parser.Infrastructure.ParseService;
using Company.Parser.Infrastructure.Providers;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Parser;

public static class AppStart
{
    /// <summary>
    /// Добавление сервисов для работы с Company.Parser
    /// </summary>
    /// <typeparam name="TDbContext">DbContext.</typeparam>
    /// <typeparam name="TParserBackground">Тип парсера.</typeparam>
    /// <param name="services">Специальный контракт для коллекции дескрипторов служб.</param>
    public static void AddParser<TDbContext, TParserBackground>(this IServiceCollection services)
        where TDbContext : ParserDbContext
        where TParserBackground : ParserBackground<TDbContext>
    {
        services.AddTransient<IHtmlLoader, HtmlLoader>();

        services.AddScoped<IBaseRepository<TDbContext, FieldConfiguration>, BaseRepository<TDbContext, FieldConfiguration>>();
        services.AddScoped<IBaseRepository<TDbContext, ConfigurationParser>, BaseRepository<TDbContext, ConfigurationParser>>();
        services.AddScoped<IBaseRepository<TDbContext, InfoParser>, BaseRepository<TDbContext, InfoParser>>();
        services.AddScoped<IBaseRepository<TDbContext, InfoURL>, BaseRepository<TDbContext, InfoURL>>();

        services.AddScoped<IURLProvider, URLProvider<TDbContext>>();
        services.AddScoped<IURLBackgroundTaskProvider, URLBackgroundTaskProvider<TDbContext>>();
        services.AddScoped<IFieldConfigurationProvider, FieldConfigurationProvider<TDbContext>>();
        services.AddScoped<IConfigurationParserProvider, ConfigurationParserProvider<TDbContext>>();
        services.AddScoped<IParserProvider, ParserProvider<TDbContext>>();
        services.AddScoped<IEntityProvider<TDbContext>, EntityProvider<TDbContext>>();

        services.AddTransient<IURLManager<TDbContext>, URLManager<TDbContext>>();
        services.AddTransient<IFieldParserManager<TDbContext>, FieldConfigurationManager<TDbContext>>();
        services.AddTransient<IConfigurationParserManager<TDbContext>, ConfigurationParserManager<TDbContext>>();
        services.AddTransient<IParserManager<TDbContext>, ParserManager<TDbContext, TParserBackground>>();

        services.AddTransient<IParseResultsHandler, ParseResultsHandler>();
        services.AddTransient<IParserPage, ParserPage>();
        services.AddTransient<IParserWorker, ParserWorker<TDbContext>>();

        services.AddSingleton<TParserBackground>();

        services.AddControllers()
            .AddMvcOptions(o => o.Conventions.Add(new GenericRestControllerNameConvention()))
            .ConfigureApplicationPartManager(c =>
            {
                c.FeatureProviders.Add(new GenericRestControllerFeatureProvider<TDbContext>());
            });

        services.AddAutoMapper(x => x.AddProfiles(
            new List<Profile>() 
            { 
                new ParserMapperConfig(), 
                new ConfigurationParserMapperConfig(), 
                new FieldConfigurationMapperConfig(),
                new URLMapperConfig()
            }));
    }
}