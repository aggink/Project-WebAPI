using AutoMapper;
using Calabonga.UnitOfWork;
using Company.Entity.Base;
using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Managers.Base;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Managers.ProductManagers.Base;

public abstract class BaseProductManager<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TContext> 
    : BaseManager<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TContext>, IProductManager<CreateViewModel, UpdateViewModel, ViewModel>
    where TContext : DbContext
    where TEntity : Auditable
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    private readonly IProductProvider<TEntity> _provider;

    public BaseProductManager(
        IRepository<TContext, TEntity> repository,
        IProductProvider<TEntity> provider,
        IMapper mapper) : base(repository, mapper)
    {
        _provider = provider;
    }


    public async Task<IPagedList<ViewModel>?> GetPageAsync(Guid parserId, int pageIndex = 0, int pageSize = 50, string? conditionSort = null, SortEnum typeSort = SortEnum.None)
    {
        var result = await _provider.GetPageAsync(parserId, pageIndex, pageSize, conditionSort, typeSort);
        if (result == null || result.Items == null) return null;

        return _mapper.Map<IPagedList<TEntity>, IPagedList<ViewModel>>(result);
    }
}