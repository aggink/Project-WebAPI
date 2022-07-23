using Company.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Интерфейс предоставляет доступ к методам CRUD
    /// </summary>
    /// <typeparam name="TContext">DbContext</typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class, IGuidId
    {
        /// <summary>
        /// Создать сущность в БД
        /// </summary>
        /// <param name="model"></param>
        /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
        Task<bool> CreateAsync(TEntity model);

        /// <summary>
        /// Обновить сущность в БД
        /// </summary>
        /// <param name="model"></param>
        /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
        Task<bool> UpdateAsync(TEntity model);

        /// <summary>
        /// Удалить сущность в БД
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
        Task<bool> DeleteAsync(Guid Id);

        /// <summary>
        /// Удалить сущность в БД 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>При успешном выполнении вернет true. В случае ошибки возвращается false.</returns>
        Task<bool> DeleteFullAsync(Guid Id);

        /// <summary>
        /// Получить сущность по id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>При успешном выполнении вернет сущность. В случае ошибке вернет null.</returns>
        Task<TEntity?> GetByIdAsync(Guid Id);
    }
}