using AutoMapper;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Managers.Base;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers;

public class FieldParserManager 
    : BaseManager<CreateFieldParserViewModel, UpdateFieldParserViewModel, FieldParserViewModel, FieldParser, ParserDbContext>, 
    IFieldParserManager
{
    private readonly IFieldParserProvider _provider;
    private readonly IWorkParserProvider _workParserProvider;

    public FieldParserManager(
        IRepository<ParserDbContext, FieldParser> repository,
        IWorkParserProvider workParserProvider,
        IFieldParserProvider provider, 
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
        _workParserProvider = workParserProvider;
    }

    public override async Task<bool> CreateAsync(CreateFieldParserViewModel entity, string userName)
    {
        var result = await _workParserProvider.GetByParserIdAsync(entity.PropertyParserId);
        if (result != null && result.IsStart) return false;

        return await base.CreateAsync(entity, userName);
    }

    public override async Task<bool> UpdateAsync(UpdateFieldParserViewModel entity, string userName)
    {
        var result = await _workParserProvider.GetByParserIdAsync(entity.PropertyParserId);
        if (result != null && result.IsStart) return false;

        return await base.UpdateAsync(entity, userName);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        var result = await _workParserProvider.GetByParserIdAsync(entity.PropertyParserId);
        if (result != null && result.IsStart) return false;

        return await base.DeleteAsync(id);
    }

    public async Task<bool> CreateAsync(IList<CreateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
        {
            var result = await _workParserProvider.GetByParserIdAsync(models[i].PropertyParserId);
            if (result != null && result.IsStart) IsOk = false;
            else IsOk = await base.CreateAsync(models[i], userName);
        }

        if (!IsOk) return false;
        return true;
    }

    public async Task<bool> UpdateAsync(IList<UpdateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
        {
            var result = await _workParserProvider.GetByParserIdAsync(models[i].PropertyParserId);
            if (result != null && result.IsStart) IsOk = false;
            else IsOk = await base.UpdateAsync(models[i], userName);
        }

        if(!IsOk) return false;
        return true;
    }

    public async Task<IList<FieldParserViewModel>?> GetByPropertyIdAsync(Guid propertyParserId)
    {
        var entities = await _provider.GetAllByPropertyIdAsync(propertyParserId);
        if (entities == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<IList<FieldParser>, IList<FieldParserViewModel>>(entities);
    }
}