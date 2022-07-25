using AutoMapper;
using Company.Entity.Base;
using Company.WebAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Managers.Base;

public abstract class BaseManager<CreateViewModel, UpdateViewModel, ViewModel, TEntity, TContext> : IBaseManager<CreateViewModel, UpdateViewModel, ViewModel>
    where TContext : DbContext
    where TEntity : Auditable
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    protected readonly IRepository<TContext, TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseManager(
        IRepository<TContext, TEntity> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<string> Errors { get; private set; } = new List<string>();

    public virtual async Task<bool> CreateAsync(CreateViewModel entity, string userName)
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

    public virtual async Task<bool> UpdateAsync(UpdateViewModel entity, string userName)
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

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result)
        {
            Errors.Add("An error occurred while deleting data.");
            return false;
        }

        return true;
    }

    public virtual async Task<ViewModel?> GetByIdAsync(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            Errors.Add("The requested data was not found.");
            return null;
        }

        return _mapper.Map<TEntity, ViewModel>(result);
    }
}