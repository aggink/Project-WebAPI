using Company.Base.Infractructure.Repository;
using Company.Parser.Entities;
using Company.Parser.Entities.Base;
using Company.Parser.Extensions;
using Company.Parser.Infrastructure.ParseService.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.Models.ParserBackgroundModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Parser.Infrastructure.ParseService;

/// <summary>
/// Класс предоставляющий реализацию обработчика результатов парсинга
/// </summary>
public class ParseResultsHandler : IParseResultsHandler
{
    private readonly IServiceProvider _serviceProvider;

    public ParseResultsHandler(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Создание сущностей на основе полученных значений с парсинга веб-ресурсов и сохранение результатов в БД.
    /// </summary>
    /// <typeparam name="TDbContext">DbContext.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="value">Объект с результатами обработки веб-страницы.</param>
    /// <returns>True - метод завершился успешно. False - в ходе работы метода возникли ошибки или список групп значений для подстановки пуст или null.</returns>
    /// <exception cref="AggregateException">При сохранении результата произошла ошибка.</exception>
    public async Task CreateEntityAsync<TDbContext, TEntity>(Value value)
        where TEntity : ParserAuditable
        where TDbContext : DbContext
    {
        using var scope = _serviceProvider.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, TEntity>>();

        var type = typeof(TEntity);
        TEntity entity = (TEntity)(Activator.CreateInstance(type) ?? throw new Exception($"Failed to create variable of type {type.FullName}"));

        foreach (var parameter in value.Parameters)
            entity = Property.SetValueInProperty(entity, parameter);

        entity.InfoURLId = value.InfoURLId;
        await repository.CreateAsync(entity);
    }

    /// <summary>
    /// Обновление или создание сущности на основе полученных значений парсинга и сохранение в БД.
    /// </summary>
    /// <typeparam name="TDbContext">Тип DbContext.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="infoURL">Сведения о ссылке.</param>
    /// <param name="value">Объект с результатами обработки веб-страницы.</param>
    /// <returns>True - метод завершился успешно. False - в ходе работы метода возникли ошибки или список групп значений для подстановки пуст или null.</returns>
    /// <exception cref="AggregateException">При сохранении результата произошла ошибка.</exception>
    public async Task CreateOrUpdateEntityAsync<TDbContext, TEntity>(InfoURL infoURL, Value value)
        where TEntity : ParserAuditable
        where TDbContext : DbContext
    {
        using var scope = _serviceProvider.CreateScope();
        var provider = scope.ServiceProvider.GetRequiredService<IEntityProvider<TDbContext>>();

        var entity = await provider.GetEntityByURLIdAsync<TEntity>(infoURL.Id);
        if (entity == null)
        {
            await CreateEntityAsync<TDbContext, TEntity>(value);
        }
        else
        {
            foreach (var parameter in value.Parameters)
                entity = Property.SetValueInProperty(entity, parameter);

            var repository = scope.ServiceProvider.GetRequiredService<IBaseRepository<TDbContext, TEntity>>();
            await repository.UpdateAsync(entity);
        }
    }
}