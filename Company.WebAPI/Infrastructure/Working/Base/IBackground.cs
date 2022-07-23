namespace Company.WebAPI.Infrastructure.Working.Base;

public interface IBackground
{
    /// <summary>
    /// Выполнить задачу
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task ExecuteAsync(IServiceProvider serviceProvider, CancellationToken token);
}
