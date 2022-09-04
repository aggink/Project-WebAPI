using Calabonga.UnitOfWork;
using Company.Base.Enums;
using Company.Parser.Data;
using Company.Parser.ViewModels.ParserViewModels;

namespace Company.Parser.Infrastructure.Managers.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы по работе с данными WorkParser
/// </summary>
public interface IParserManager<TDbContext>
    where TDbContext : ParserDbContext
{
    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="userName">Уникальное имя пользователя.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task CreateAsync(string userName);

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>True - операция завершилась успешно. False - операция завершилась с ошибкой.</returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Получить сущность по индентификатору.
    /// </summary>
    /// <param name="id">Индентификатор сущности.</param>
    /// <returns>Сущность или null, если ничего не найдено.</returns>
    Task<ParserViewModel> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить страницу.
    /// </summary>
    /// <param name="pageIndex">Номер страницы.</param>
    /// <param name="pageSize">Количество элементов на страницы.</param>
    /// <param name="typeSort">Тип сортировки.</param>
    /// <returns>Страница с данными.</returns>
    Task<IPagedList<ParserViewModel>> GetPageAsync(int pageIndex = 0, int pageSize = 50, SortEnum typeSort = 0);

    /// <summary>
    /// Добавть задачу в очередь на выполнение.
    /// </summary>
    /// <param name="id">Индентификатор задачи</param>
    /// <param name="userName">Имя пользователя внесшего последние изменения</param>
    /// <returns>True - Задача успешно добавлена. False - Произошла ошибка при добавлении задачи.</returns>
    Task AddTaskQueueAsync(Guid id, string userName);

    /// <summary>
    /// Удалить парсер из очереди.
    /// </summary>
    /// <param name="id">Индентификатор парсера.</param>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    /// <exception cref="Exception">Ошибка при проверки значений парсера.</exception>
    Task DeleteTaskQueueAsync(Guid id, string userName);

    /// <summary>
    /// Остановить активную задачу.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns>Task.</returns>
    /// <exception cref="Exception">Активных задач нет.</exception>
    Task StopActiveTaskAsync(string userName);
}