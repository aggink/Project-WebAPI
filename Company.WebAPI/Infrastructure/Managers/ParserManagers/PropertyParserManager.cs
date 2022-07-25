using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Managers.Base;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers;

public class PropertyParserManager : 
    BaseManager<CreatePropertyParserViewModel, UpdatePropertyParserViewModel, PropertyParserViewModel, PropertyParser, ParserDbContext>, 
    IPropertyParserManager
{
    private readonly IPropertyParserProvider _provider;
    private readonly IWorkParserProvider _workParserProvider;

    public PropertyParserManager(
        IRepository<ParserDbContext, PropertyParser> repository,
        IPropertyParserProvider provider,
        IWorkParserProvider workParserProvider, 
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
        _workParserProvider = workParserProvider;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        // Проверка - используются ли данные при работе парсера
        var workParser = await _workParserProvider.GetByParserIdAsync(id);
        if (workParser != null || workParser!.IsStart)
        {
            Errors.Add("The data cannot be changed at this time. The data is used in the parser.");
            return false;
        }

        await base.DeleteAsync(id);

        return true;
    }

    public async Task<IList<PropertyParserViewModel>?> GetAllAsync()
    {
        var entities = await _provider.GetAllWithDependencies();
        if (entities == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<IList<PropertyParser>, IList<PropertyParserViewModel>>(entities);
    }
}