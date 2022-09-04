namespace Company.Base.Infractructure.BackgroundWorks.Base;

/// <summary>
/// Интерфейс для реализации фоновой задачи
/// </summary>
public interface IBackground
{
    /// <summary>
    /// Выполнить задачу
    /// </summary>
    /// <param name="serviceProvider">Интерфейс для извлечения объекта службы</param>
    /// <param name="token">Уведомление об отмене</param>
    /// <returns></returns>
    Task ExecuteAsync(IServiceProvider serviceProvider, CancellationToken token);
}