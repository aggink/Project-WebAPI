using Calabonga.UnitOfWork;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers;

/// <summary>
/// Класс для взаимодействия с БД (работа с конфигурациями)
/// </summary>
public class ConfigurationParserProvider<TDbContext> : IConfigurationParserProvider
    where TDbContext : ParserDbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;

    public ConfigurationParserProvider(
        IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить сущность с добавленными парсерами
    /// </summary>
    /// <param name="id">Индентификатор конфигурации</param>
    /// <returns></returns>
    public async Task<ConfigurationParser?> GetByIdWithParsersAsync(Guid id)
    {
        return await _unitOfWork.GetRepository<ConfigurationParser>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: x => x.Include(x => x.Parser!));
    }

    /// <summary>
    /// Получить сущность с полями конфигураций
    /// </summary>
    /// <param name="id">Индентификатор конфигурации</param>
    /// <returns>Конфигурация парсера</returns>
    public async Task<ConfigurationParser?> GetByIdWithFieldsAsync(Guid id)
    {
        return await _unitOfWork.GetRepository<ConfigurationParser>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: i => i.Include(x => x.Fields));
    }

    /// <summary>
    /// Получить список конфигураций по индетификатору парсера
    /// </summary>
    /// <param name="parserId">Индентификатор парсера</param>
    /// <returns>Список конфигураций</returns>
    public async Task<IEnumerable<ConfigurationParser>> GetByParserIdWithFieldsAsync(Guid parserId)
    {
        return await _unitOfWork.GetRepository<ConfigurationParser>().GetAllAsync(
            predicate: x => x.ParserId == parserId,
            include: x => x.Include(x => x.Parser!));
    }

    /// <summary>
    /// Получить все сущности со всеми зависимыми полями
    /// </summary>
    /// <returns>Список конфигураций</returns>
    public async Task<IEnumerable<ConfigurationParser>> GetAllAsync()
    {
        return await _unitOfWork.GetRepository<ConfigurationParser>().GetAllAsync(
            include: i => i.Include(x => x.Fields));
    }

    /// <summary>
    /// Находятся ли на выполнении фоновые задачи с заданным индетификатором конфигурации.
    /// </summary>
    /// <param name="id">Индетификатор конфигурации.</param>
    /// <returns>True - с данным id находятся на выполнении фоновые задачи или значение не найдено. False - с данным id нет выполняемых фоновых задач.</returns>
    public async Task<bool> IsActiveTaskOrNotFoundAsync(Guid id)
    {
        var configurationParser = await GetByIdWithParsersAsync(id);
        if (configurationParser == null) return true;

        return configurationParser.Parser!.IsStart;
    }
}