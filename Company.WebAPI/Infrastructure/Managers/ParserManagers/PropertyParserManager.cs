using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ParserViewModels.PropertyParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers;

public class PropertyParserManager : IPropertyParserManager
{
    private readonly IRepository<ProductDbContext, PropertyParser> _repository;
    private readonly IPropertyParserProvider _provider;
    private readonly IWorkParserProvider _workParserProvider;
    private readonly IMapper _mapper;

    public PropertyParserManager(
        IRepository<ProductDbContext, PropertyParser> repository,
        IPropertyParserProvider provider,
        IWorkParserProvider workParserProvider, 
        IMapper mapper)
    {
        _repository = repository;
        _provider = provider;
        _workParserProvider = workParserProvider;
        _mapper = mapper;
    }

    public List<string> Errors { get; private set; } = new List<string>();

    public async Task<bool> CreateAsync(CreatePropertyParserViewModel model, string userName)
    {
        var entity = _mapper.Map<CreatePropertyParserViewModel, PropertyParser>(model);
        entity.CreatedBy = userName;
        entity.UpdatedBy = userName;

        var result = await _repository.CreateAsync(entity);
        if (!result)
        {
            Errors.Add("Error while saving data.");
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(UpdatePropertyParserViewModel model, string userName)
    {
        var entity = _mapper.Map<UpdatePropertyParserViewModel, PropertyParser>(model);
        entity.UpdatedBy = userName;

        var result = await _repository.UpdateAsync(entity);
        if (!result)
        {
            Errors.Add("An error occurred while changing the data.");
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        // Проверка - используются ли данные при работе парсера
        var workParser = await _workParserProvider.GetByPropertyParserAsync(id);
        if (workParser != null || workParser!.IsStart)
        {
            Errors.Add("The data cannot be changed at this time. The data is used in the parser.");
            return false;
        }

        var result = await _repository.DeleteAsync(id);
        if (!result)
        {
            Errors.Add("An error occurred while deleting data.");
            return false;
        }

        return true;
    }

    public async Task<PropertyParserViewModel?> GetByIdAsync(Guid id)
    {
        var entity = await _provider.GetWithDependenciesById(id);
        if (entity == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<PropertyParser, PropertyParserViewModel>(entity);
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