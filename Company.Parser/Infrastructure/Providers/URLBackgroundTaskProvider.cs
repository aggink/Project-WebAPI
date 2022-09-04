using Calabonga.UnitOfWork;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Providers.Interfaces;

namespace Company.Parser.Infrastructure.Providers;

/// <summary>
/// Класс для взаимодействия с БД (работа с ссылками)
/// </summary>
public class URLBackgroundTaskProvider<TDbContext> : IURLBackgroundTaskProvider
    where TDbContext : ParserDbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;

    public URLBackgroundTaskProvider(IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить необработанную ссылку.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Ссылка.</returns>
    public async Task<InfoURL?> GetFollowLinkAsync(Guid parserId)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetFirstOrDefaultAsync(
            predicate: x => x.ParserId == parserId && x.HasBeenProcessed == false,
            orderBy: x => x.OrderBy(x => x.UpdatedAt));
    }

    /// <summary>
    /// Вернуть те ссылки, которых нет в базе данных.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <param name="links">Список ссылок полученных с веб-страницы.</param>
    /// <returns>Список ссылок, которых нет в базе данных.</returns>
    /// <exception cref="ArgumentException">Ошибка при получение dbContext.</exception>
    public async Task<IEnumerable<string>> GetLinksNotStoredByDBAsync(Guid parserId, IEnumerable<string> links)
    {
        return links.Except(await _unitOfWork.GetRepository<InfoURL>().GetAllAsync(predicate: x => x.ParserId == parserId, selector: s => s.Url));
    }

    /// <summary>
    /// Получить все ссылки по заданному индентификатору парсера.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Список ссылок.</returns>
    public async Task<IEnumerable<InfoURL>> GetByParserIdAsync(Guid parserId)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetAllAsync(
            predicate: x => x.ParserId == parserId);
    }

    /// <summary>
    /// Получить список ссылок по индентификатору парсера.
    /// </summary>
    /// <param name="parserId">Индентификатор парсера.</param>
    /// <returns>Список ссылок относящийхся к одному парсеру.</returns>
    public async Task<IEnumerable<InfoURL>> GetLinksByParserIdAsync(Guid parserId)
    {
        return await _unitOfWork.GetRepository<InfoURL>().GetAllAsync(
            predicate: x => x.ParserId == parserId);
    }
}