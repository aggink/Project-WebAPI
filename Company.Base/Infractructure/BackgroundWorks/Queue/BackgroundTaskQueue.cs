using Company.Base.Infractructure.BackgroundWorks.Base;
using System.Collections.Concurrent;

namespace Company.Base.Infrastructure.BackgroundWorks.Queue;

/// <summary>
/// Очередь фоновых задач
/// </summary>
public class BackgroundTaskQueue<TBackground> : IBackgroundTaskQueue<TBackground>
    where TBackground : class, IBackground
{
    /// <summary>
    /// Представляет коллекция по принципу "первым поступил - первым обслужен"
    /// </summary>
    private readonly ConcurrentQueue<Func<CancellationToken, TBackground>> _workItems = new();

    /// <summary>
    /// Представляет упрощенную альтернативу семафору Semaphore, ограничивающему количество потоков, которые могут параллельно обращаться к ресурсу или пулу ресурсов.
    /// </summary>
    private readonly SemaphoreSlim _signal = new(0);

    public async Task<Func<CancellationToken, TBackground>?> DequeueAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        _workItems.TryDequeue(out var workItem);

        return workItem;
    }

    public void QueueBackgroundWorkItem(Func<CancellationToken, TBackground> workItem)
    {
        if (workItem == null) throw new ArgumentNullException(nameof(workItem));

        _workItems.Enqueue(workItem);
        _signal.Release();
    }
}
