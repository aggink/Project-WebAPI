namespace Company.WebAPI.Infrastructure.Managers.Base;

public interface IBaseManager<CreateViewModel, UpdateViewModel, ViewModel>
    where CreateViewModel : class
    where UpdateViewModel : class
    where ViewModel : class
{
    /// <summary>
    /// Создание элемента
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> CreateAsync(CreateViewModel entity, string userName);

    /// <summary>
    /// Обновление элемента
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(UpdateViewModel entity, string userName);

    /// <summary>
    /// Удаление элемента
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id);

    /// <summary>
    /// Получить элемент
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ViewModel?> GetByIdAsync(Guid id);
}