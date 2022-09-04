using AutoMapper;
using Company.Base.Infractructure.Manager;
using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.ViewModels.FieldConfigurationViewModels;

namespace Company.Parser.Infrastructure.Managers;

public class FieldConfigurationManager<TDbContext> 
    : BaseManager<CreateFieldConfigurationViewModel, UpdateFieldConfigurationViewModel, FieldConfigurationViewModel, FieldConfiguration, TDbContext>, 
    IFieldParserManager<TDbContext>
    where TDbContext : ParserDbContext
{
    private readonly IFieldConfigurationProvider _provider;
    private readonly IConfigurationParserProvider _configurationProvider;

    public FieldConfigurationManager(
        IBaseRepository<TDbContext, FieldConfiguration> repository,
        IFieldConfigurationProvider provider,
        IConfigurationParserProvider configurationParserProvider,
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
        _configurationProvider = configurationParserProvider;
    }

    private static string ActiveTaskConfigIdMessageError(Guid id) => $"The task with configuration (configurationId = {id}) is active. Changes are not possible.";
    private static string ActiveTaskFieldIdMessageError(Guid id) => $"The task with field (fieldId = {id}) is active. Changes are not possible.";

    #region CRUD

    public override async Task CreateAsync(CreateFieldConfigurationViewModel entity, string userName)
    {
        if (await _configurationProvider.IsActiveTaskOrNotFoundAsync(entity.ConfigurationId))
            throw new Exception(ActiveTaskConfigIdMessageError(entity.ConfigurationId));

        await base.CreateAsync(entity, userName);
    }

    public override async Task CreateAsync(IEnumerable<CreateFieldConfigurationViewModel> entities, string userName)
    {
        foreach (var configurationId in entities.Select(x => x.ConfigurationId).Distinct())
        {
            if (await _configurationProvider.IsActiveTaskOrNotFoundAsync(configurationId))
                throw new Exception(ActiveTaskConfigIdMessageError(configurationId));
        }

        await base.CreateAsync(entities, userName);
    }

    public override async Task UpdateAsync(UpdateFieldConfigurationViewModel entity, string userName)
    {
        if (await _configurationProvider.IsActiveTaskOrNotFoundAsync(entity.ConfigurationId))
            throw new Exception(ActiveTaskConfigIdMessageError(entity.ConfigurationId));

        await base.UpdateAsync(entity, userName);
    }

    public override async Task UpdateAsync(IEnumerable<UpdateFieldConfigurationViewModel> entities, string userName)
    {
        foreach (var configurationId in entities.Select(x => x.ConfigurationId).Distinct())
        {
            if (await _configurationProvider.IsActiveTaskOrNotFoundAsync(configurationId))
                throw new Exception(ActiveTaskConfigIdMessageError(configurationId));
        }

        await base.UpdateAsync(entities, userName);
    }


    public override async Task DeleteAsync(Guid id)
    {
        if (await _provider.IsActiveTaskOrNotFoundAsync(id))
            throw new Exception(ActiveTaskFieldIdMessageError(id));

        await base.DeleteAsync(id);
    }

    public override async Task DeleteAsync(IEnumerable<Guid> ids)
    {
        foreach(var id in ids)
        {
            if (await _provider.IsActiveTaskOrNotFoundAsync(id))
                throw new Exception(ActiveTaskFieldIdMessageError(id));
        }

        await base.DeleteAsync(ids);
    }

    #endregion

    /// <summary>
    /// Получить все поля относящиеся к одной настройке парсера
    /// </summary>
    /// <param name="configurationId">Индетификатор конфигурации</param>
    /// <returns>Список полей</returns>
    public async Task<IEnumerable<FieldConfigurationViewModel>> GetByPropertyIdAsync(Guid configurationId)
    {
        var entities = await _provider.GetAllByPropertyIdAsync(configurationId);
        return _mapper.Map<IEnumerable<FieldConfiguration>, IEnumerable<FieldConfigurationViewModel>>(entities);
    }
}