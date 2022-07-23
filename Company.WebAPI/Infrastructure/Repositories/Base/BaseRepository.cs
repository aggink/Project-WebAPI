using Calabonga.UnitOfWork;
using Company.Entity.Base;
using Company.WebAPI.Infrastructure.EventLogging;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Реализация методов CRUD.
    /// </summary>
    /// <typeparam name="TContext">DbContext</typeparam>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    public abstract class BaseRepository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class, IGuidId
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<TEntity> _repository;
        protected readonly ILogger<BaseRepository<TContext, TEntity>> _logger;
        public BaseRepository(
            IUnitOfWork<TContext> unitOfWork,
            ILogger<BaseRepository<TContext, TEntity>> logger)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<TEntity>();
            _logger = logger;
        }

        #region Create

        /// <summary>
        /// Установка данных для создания записи в БД
        /// </summary>
        /// <param name="inputEntity">Данные для сохранения в БД</param>
        /// <returns></returns>
        protected abstract TEntity CreateEntity(TEntity inputEntity);

        public async Task<bool> CreateAsync(TEntity model)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _repository.InsertAsync(CreateEntity(model));
                await _unitOfWork.SaveChangesAsync();
                if (!_unitOfWork.LastSaveChangesResult.IsOk)
                {
                    throw _unitOfWork.LastSaveChangesResult.Exception!;
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await transaction.CommitAsync();
                _logger.EntitySaveFailed(nameof(TEntity), ex);
                return false;
            }
        }

        #endregion

        #region Delete

        public async Task<bool> DeleteAsync(Guid Id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id!.Equals(Id));
                if (entity == null) return false;

                _repository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
                if (!_unitOfWork.LastSaveChangesResult.IsOk)
                {
                    throw _unitOfWork.LastSaveChangesResult.Exception!;
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await transaction.CommitAsync();
                _logger.EntityDeleteFailed(nameof(TEntity), ex);
                return false;
            }
        }

        /// <summary>
        /// Установка данных для удаления записи в БД
        /// </summary>
        /// <param name="id">Индентификатор сущности для удаления</param>
        /// <returns></returns>
        protected abstract Task<TEntity?> DeleteEntityAsync(Guid id);

        public async Task<bool> DeleteFullAsync(Guid id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = await DeleteEntityAsync(id);
                if (entity == null) return false;

                _repository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
                if (!_unitOfWork.LastSaveChangesResult.IsOk)
                {
                    throw _unitOfWork.LastSaveChangesResult.Exception!;
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await transaction.CommitAsync();
                _logger.EntityDeleteFailed(nameof(TEntity), ex);
                return false;
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Установка данных для обновления записи в БД
        /// </summary>
        /// <param name="entity">Данные из БД</param>
        /// <param name="inputEntity">Измененные данные</param>
        /// <returns></returns>
        protected abstract TEntity UpdateEntity(TEntity entity, TEntity inputEntity);

        public async Task<bool> UpdateAsync(TEntity model)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var entity = await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id!.Equals(model.Id));
                if (entity == null) return false;

                _repository.Update(UpdateEntity(entity, model));
                await _unitOfWork.SaveChangesAsync();
                if (!_unitOfWork.LastSaveChangesResult.IsOk)
                {
                    throw _unitOfWork.LastSaveChangesResult.Exception!;
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await transaction.CommitAsync();
                _logger.EntityUpdateFailed(nameof(TEntity), ex);
                return false;
            }
        }

        #endregion

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
            if (entity == null)
            {
                _logger.EntityReadFailed(nameof(TEntity), null);
            }
            return entity;
        }
    }
}