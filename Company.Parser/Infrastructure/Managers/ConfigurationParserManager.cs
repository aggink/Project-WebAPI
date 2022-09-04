using AutoMapper;
using Company.Base.Infractructure.Manager;
using Company.Base.Infractructure.Repository;
using Company.Parser.Data;
using Company.Parser.Entities;
using Company.Parser.Infrastructure.Managers.Interfaces;
using Company.Parser.Infrastructure.Providers.Interfaces;
using Company.Parser.ViewModels.ConfigurationParserViewModels;

namespace Company.Parser.Infrastructure.Managers;

public class ConfigurationParserManager<TDbContext> : 
    BaseManager<CreateConfigurationParserViewModel, UpdateConfigurationParserViewModel, ConfigurationParserViewModel, ConfigurationParser, TDbContext>, 
    IConfigurationParserManager<TDbContext>
    where TDbContext : ParserDbContext
{
    private readonly IConfigurationParserProvider _provider;
    private readonly IParserProvider _parserProvider;

    public ConfigurationParserManager(
        IBaseRepository<TDbContext, ConfigurationParser> repository,
        IConfigurationParserProvider provider,
        IParserProvider parserProvider,
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
        _parserProvider = parserProvider;
    }

    private static string ActiveTaskMessageError(Guid id) => $"The task (parserId = {id}) is active. Changes are not possible.";
    private static string ActiveTaskConfigIdMessageError(Guid id) => $"The task with configuration (configurationId = {id}) is active. Changes are not possible.";

    #region CRUD

    public override async Task CreateAsync(CreateConfigurationParserViewModel entity, string userName)
    {
        if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId)) 
            throw new Exception(ActiveTaskMessageError(entity.ParserId));

        await base.CreateAsync(entity, userName);
    }

    public override async Task CreateAsync(IEnumerable<CreateConfigurationParserViewModel> entities, string userName)
    {
        foreach(var entity in entities)
        {
            if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId)) 
                throw new Exception(ActiveTaskMessageError(entity.ParserId));
        }

        await base.CreateAsync(entities, userName);
    }

    public override async Task UpdateAsync(UpdateConfigurationParserViewModel entity, string userName)
    {
        if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId)) 
            throw new Exception(ActiveTaskMessageError(entity.ParserId));

        await base.UpdateAsync(entity, userName);
    }

    public override async Task UpdateAsync(IEnumerable<UpdateConfigurationParserViewModel> entities, string userName)
    {
        foreach(var entity in entities)
        {
            if (await _parserProvider.IsActiveTaskOrNotFoundAsync(entity.ParserId)) 
                throw new Exception(ActiveTaskMessageError(entity.ParserId));
        }

        await base.UpdateAsync(entities, userName);
    }

    public override async Task DeleteAsync(Guid id)
    {
        if (await _provider.IsActiveTaskOrNotFoundAsync(id)) 
            throw new Exception(ActiveTaskConfigIdMessageError(id));

        await base.DeleteAsync(id);
    }

    public override async Task DeleteAsync(IEnumerable<Guid> ids)
    {
        foreach(var id in ids)
        {
            if (await _provider.IsActiveTaskOrNotFoundAsync(id)) 
                throw new Exception(ActiveTaskConfigIdMessageError(id));
        }

        await base.DeleteAsync(ids);
    }

    #endregion
}