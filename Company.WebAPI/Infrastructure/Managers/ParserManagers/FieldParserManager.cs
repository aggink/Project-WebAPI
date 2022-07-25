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

    public FieldParserManager(
        IRepository<ParserDbContext, FieldParser> repository,
        IFieldParserProvider provider, 
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
    }

    public async Task<bool> CreateAsync(IList<CreateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
            IsOk = await base.CreateAsync(models[i], userName);

        if (!IsOk) return false;
        return true;
    }

    public async Task<bool> UpdateAsync(IList<UpdateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
            IsOk = await base.UpdateAsync(models[i], userName);

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