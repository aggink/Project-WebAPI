using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Entity.Base;
using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Managers.ProductManagers.Interfaces;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;

public abstract class BaseProductManager<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TContext> : IProductManager<CreateViewModel, UpdateViewModel, ViewModel>
    where TContext : DbContext
    where TEntity : Auditable
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    private readonly IRepository<TContext, TEntity> _repository;
    private readonly IProductProvider<TEntity> _provider;
    private readonly IMapper _mapper;

    public BaseProductManager(
        IRepository<TContext, TEntity> repository,
        IProductProvider<TEntity> provider,
        IMapper mapper)
    {
        _repository = repository;
        _provider = provider;
        _mapper = mapper;
    }

    public List<string> Errors { get; private set; } = new List<string>();

    public async Task<bool> CreateAsync(CreateViewModel entity, string userName)
    {
        var model = _mapper.Map<CreateViewModel, TEntity>(entity);
        model.CreatedBy = userName;
        model.UpdatedBy = userName;

        var result = await _repository.CreateAsync(model);
        if (!result)
        {
            Errors.Add("Error while saving data.");
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(UpdateViewModel entity, string userName)
    {
        var model = _mapper.Map<UpdateViewModel, TEntity>(entity);
        model.UpdatedBy = userName;

        var result = await _repository.UpdateAsync(model);
        if (!result)
        {
            Errors.Add("An error occurred while changing the data.");
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result)
        {
            Errors.Add("An error occurred while deleting data.");
            return false;
        }

        return true;
    }

    public async Task<ViewModel?> GetByIdAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<TEntity, ViewModel>(result);
    }

    public async Task<IPagedList<ViewModel>?> GetPageAsync(Guid parserId, int pageIndex = 0, int pageSize = 50, string? conditionSort = null, SortEnum typeSort = SortEnum.None)
    {
        var result = await _provider.GetPageAsync(parserId, pageIndex, pageSize, conditionSort, typeSort);
        if (result == null || result.Items == null) return null;

        return _mapper.Map<IPagedList<TEntity>, IPagedList<ViewModel>>(result);
    }
}
