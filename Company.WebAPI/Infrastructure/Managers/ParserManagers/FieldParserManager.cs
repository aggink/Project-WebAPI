using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.Entity.Parser;
using Company.WebAPI.Infrastructure.Managers.ParserManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ParserProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Company.WebAPI.ViewModels.ParserViewModels.FieldParserViewModels;

namespace Company.WebAPI.Infrastructure.Managers.ParserManagers;

public class FieldParserManager : IFieldParserManager
{
    private readonly IRepository<ProductDbContext, FieldParser> _repository;
    private readonly IFieldParserProvider _provider;
    private readonly IMapper _mapper;

    public FieldParserManager(
        IRepository<ProductDbContext, FieldParser> repository,
        IFieldParserProvider provider, 
        IMapper mapper)
    {
        _repository = repository;
        _provider = provider;
        _mapper = mapper;
    }

    public List<string> Errors { get; private set; } = new List<string>();

    public async Task<bool> CreateAsync(IList<CreateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
        {
            var entity = _mapper.Map<CreateFieldParserViewModel, FieldParser>(models[i]);
            entity.CreatedBy = userName;
            entity.UpdatedBy = userName;

            var result = await _repository.CreateAsync(entity);
            if (!result)
            {
                Errors.Add("Error while saving data.");
                IsOk = false;
            }
        }

        if (!IsOk) return false;
        return true;
    }

    public async Task<bool> UpdateAsync(IList<UpdateFieldParserViewModel> models, string userName)
    {
        bool IsOk = true;
        for (int i = 0; i < models.Count; i++)
        {
            var entity = _mapper.Map<UpdateFieldParserViewModel, FieldParser>(models[i]);
            entity.UpdatedBy = userName;

            var result = await _repository.CreateAsync(entity);
            if (!result)
            {
                Errors.Add("Error while saving data.");
                IsOk = false;
            }
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