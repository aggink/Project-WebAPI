using Calabonga.UnitOfWork;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers;

/// <summary>
/// Класс для взаимодействия с БД (работа с парсерами).
/// </summary>
public class ParserProvider<TDbContext> : IParserProvider
    where TDbContext : ParserDbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;
    public ParserProvider(IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить парсер с настройками конфигурации.
    /// </summary>
    /// <param name="id">Индентификатор парсера.</param>
    /// <returns>Сущность или null.</returns>
    public async Task<InfoParser?> GetByIdWithConfigurationsWithFieldsAsync(Guid id)
    {
        return await _unitOfWork.GetRepository<InfoParser>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: x => x.Include(x => x.Configurations).ThenInclude(x => x.Fields));
    }

    /// <summary>
    /// Получить сущность по id конфигурации.
    /// </summary>
    /// <param name="configurationId">Индентификатор конфигурации.</param>
    /// <returns>Список парсеров.</returns>
    public async Task<IEnumerable<InfoParser>> GetByConfigurationIdAsync(Guid configurationId)
    {
        return await _unitOfWork.GetRepository<InfoParser>().GetAllAsync(
            predicate: x => x.Configurations.FirstOrDefault(x => x.Id == configurationId) != null,
            include: x => x.Include(x => x.Configurations));
    }

    /// <summary>
    /// Получить все сущности.
    /// </summary>
    /// <returns>Список парсеров.</returns>
    public async Task<IEnumerable<InfoParser>> GetAllAsync()
    {
        return await _unitOfWork.GetRepository<InfoParser>().GetAllAsync(
            include: i => i.Include(x => x.Configurations));
    }

    /// <summary>
    /// Получить первый элемент со всеми зависимыми полями в  отсортированном по возрастанию (по дате) списке удовлетворяющий условиям:
    /// 1. Находится в очереди (IsQueue = true),
    /// 2. Не находится на выполнении (IsStart = false).
    /// </summary>
    /// <returns>Парсер со списком конфигураций или null.</returns>
    public async Task<InfoParser?> GetOldEntityReadyExecuteAsync()
    {
        return await _unitOfWork.GetRepository<InfoParser>().GetFirstOrDefaultAsync(
                predicate: x => x.IsQueue && !x.IsStart,
                orderBy: x => x.OrderBy(i => i.UpdatedBy),
                include: i => i.Include(x => x.Configurations).ThenInclude(x => x.Fields));
    }

    /// <summary>
    /// Получить парсер, который в данный момент находится на выполнении.
    /// </summary>
    /// <returns>Сущность или null.</returns>
    public async Task<InfoParser?> GetActiveBackgroundTaskAsync()
    {
        return await _unitOfWork.GetRepository<InfoParser>().GetFirstOrDefaultAsync(
            predicate: x => x.IsStart);
    }

    /// <summary>
    /// Находятся ли на выполнении указанный парсер или его не существует.
    /// </summary>
    /// <param name="id">Индетификатор парсера</param>
    /// <returns>True - парсер находятся на выполнении или не найден. False - парсер не активен.</returns>
    public async Task<bool> IsActiveTaskOrNotFoundAsync(Guid id)
    {
        var parser = await _unitOfWork.GetRepository<InfoParser>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id);

        if (parser == null) return true;
        return parser.IsStart;
    }
}