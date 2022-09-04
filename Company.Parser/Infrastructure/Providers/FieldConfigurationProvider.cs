using Calabonga.UnitOfWork;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.Parser.Infrastructure.Providers;

/// <summary>
/// Класс для взаимодействия с БД (работа с полями парсера)
/// </summary>
public class FieldConfigurationProvider<TDbContext> : IFieldConfigurationProvider
    where TDbContext : ParserDbContext
{
    private readonly IUnitOfWork<TDbContext> _unitOfWork;

    public FieldConfigurationProvider(
        IUnitOfWork<TDbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить все поля относящиеся к одной настройке парсера
    /// </summary>
    /// <param name="configurationId">Индетификатор конфигурации</param>
    /// <returns>Список полей</returns>
    public async Task<IEnumerable<FieldConfiguration>> GetAllByPropertyIdAsync(Guid configurationId)
    {
        return await _unitOfWork.GetRepository<FieldConfiguration>().GetAllAsync(
            predicate: x => x.ConfigurationId == configurationId);
    }

    /// <summary>
    /// Находятся ли на выполнении фоновые задачи с заданным индетификатором поля конфигурации.
    /// </summary>
    /// <param name="id">Индетификатор конфигурации.</param>
    /// <returns>True - с данным id находятся на выполнении фоновые задачи или значение не найдено. False - с данным id нет выполняемых фоновых задач.</returns>
    public async Task<bool> IsActiveTaskOrNotFoundAsync(Guid id)
    {
        var result = await _unitOfWork.GetRepository<FieldConfiguration>().GetFirstOrDefaultAsync(
            predicate: x => x.Id == id,
            include: i => i.Include(x => x.Configuration!).ThenInclude(x => x.Parser!));

        if (result == null) return true;
        else if (result!.Configuration == null) return true;
        else if (result!.Configuration!.Parser == null) return true;
        else return result!.Configuration!.Parser!.IsStart;
    }
}