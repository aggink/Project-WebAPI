using Company.Base.Infractructure.BackgroundWorks.Base;

namespace Company.Base.Infrastructure.BackgroundWorks.Queue;

/// <summary>
/// Очередь фоновых задач
/// </summary>
public interface IBackgroundTaskQueue<TBackground>
    where TBackground : class, IBackground
{
    /// <summary>
    /// Добавление элемента в конец очереди
    /// </summary>
    /// <param name="workItem"></param>
    void QueueBackgroundWorkItem(Func<CancellationToken, TBackground> workItem);

    /// <summary>
    /// Удаление из очереди
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Func<CancellationToken, TBackground>?> DequeueAsync(CancellationToken cancellationToken);
}