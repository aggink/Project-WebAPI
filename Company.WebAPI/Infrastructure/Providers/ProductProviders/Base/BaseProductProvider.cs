using Calabonga.UnitOfWork;
using Company.Entity.Base;
using Company.Entity.Products;
using Company.WebAPI.Infrastructure.Enums;
using Company.WebAPI.Infrastructure.Providers.ProductProviders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Providers.ProductProviders.Base;

public abstract class BaseProductProvider<TContect, TEntity> : IProductProvider<TEntity>
    where TContect : DbContext
    where TEntity : Auditable, IPropertyParserId
{
    private readonly IUnitOfWork<DbContext> _unitOfWork;

    public BaseProductProvider(
        IUnitOfWork<DbContext> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IPagedList<TEntity>> GetPageAsync(Guid parserId, int pageIndex = 0, int pageSize = 50, string? conditionSort = null, SortEnum typeSort = SortEnum.None)
    {
        return typeSort switch
        {
            SortEnum.OrderBy => await _unitOfWork.GetRepository<TEntity>().GetPagedListAsync(
                predicate: x => x.PropertyParserId == parserId,
                pageIndex: pageIndex,
                pageSize: pageSize,
                orderBy: x => x.OrderBy(x => conditionSort)),

            SortEnum.OrderByDescending => await _unitOfWork.GetRepository<TEntity>().GetPagedListAsync(
                predicate: x => x.PropertyParserId == parserId,
                pageIndex: pageIndex,
                pageSize: pageSize,
                orderBy: x => x.OrderByDescending(x => conditionSort)),

            _ => throw new NotImplementedException()
        };
    }
}