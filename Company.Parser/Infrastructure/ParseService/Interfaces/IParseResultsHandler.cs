using Company.Parser.Entities;
using Company.Parser.Entities.Base;
using Company.Parser.Models.ParserBackgroundModels;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.ParseService.Interfaces;

/// <summary>
/// Интерфейс для взаимодействия с обработчиком результатов парсинга
/// </summary>
public interface IParseResultsHandler
{
    /// <summary>
    /// Создание сущности на основе полученных значений парсинга и сохранение в БД.
    /// </summary>
    /// <typeparam name="TDbContext">DbContext.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="value">Объект с результатами обработки веб-страницы.</param>
    /// <returns>True - метод завершился успешно. False - в ходе работы метода возникли ошибки или список групп значений для подстановки пуст или null.</returns>
    Task CreateEntityAsync<TDbContext, TEntity>(Value value) 
        where TEntity : ParserAuditable
        where TDbContext : DbContext;

    /// <summary>
    /// Обновление или создание сущности на основе полученных значений парсинга и сохранение в БД.
    /// </summary>
    /// <typeparam name="TDbContext">DbContext.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="infoURL">Сведения о ссылке.</param>
    /// <param name="value">Объект с результатами обработки веб-страницы.</param>
    /// <returns>True - метод завершился успешно. False - в ходе работы метода возникли ошибки или список групп значений для подстановки пуст или null.</returns>
    Task CreateOrUpdateEntityAsync<TDbContext, TEntity>(InfoURL infoURL, Value value) 
        where TEntity : ParserAuditable
        where TDbContext : DbContext;
}