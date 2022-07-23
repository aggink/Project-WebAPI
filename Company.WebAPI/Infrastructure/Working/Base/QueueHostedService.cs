namespace Company.WebAPI.Infrastructure.Working.Base;

public class QueueHostedService<TBackground> : BackgroundService
    where TBackground : class, IBackground
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<QueueHostedService<TBackground>> _logger;

    public IBackgroundTaskQueue<TBackground> TaskQueue { get; }
    public QueueHostedService(
        IBackgroundTaskQueue<TBackground> taskQueue,
        IServiceProvider serviceProvider,
        ILogger<QueueHostedService<TBackground>> logger)
    {
        TaskQueue = taskQueue;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
                $"Queued Hosted Service is running.{Environment.NewLine}" +
                $"{Environment.NewLine}Tap W to add a work item to the " +
                $"background queue.{Environment.NewLine}");

        await BackgroundProcessing(stoppingToken);
    }

    private async Task BackgroundProcessing(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await TaskQueue.DequeueAsync(stoppingToken);

            try
            {
                var work = workItem?.Invoke(stoppingToken);
                await work?.ExecuteAsync(_serviceProvider, stoppingToken)!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred executing {WorkItem}.", nameof(workItem));
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Queued Hosted Service is stopping.");

        await base.StopAsync(stoppingToken);
    }
}
