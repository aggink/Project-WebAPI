using Microsoft.Extensions.Logging;

namespace Company.Base;

/// <summary>
/// Данные для Logger
/// </summary>
public static partial class EventLogger
{
    private static readonly EventId EntitySaveFailedId = new(70040001, "EntitySavingFailed");
    private static readonly EventId EntityUpdateFaildedId = new(70040002, "EntityUpdateFailed");
    private static readonly EventId EntityDeleteFailedId = new(70040003, "EntityDeleteFailed");
    private static readonly EventId EntityReadFailedId = new(70040004, "EntityReadFailed");

    private static readonly Action<ILogger, string, Exception?> EntitySaveFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntitySaveFailedId,
            "TEntity creation error: {entityName}");
    
    public static void EntitySaveFailed(this ILogger logger, string entityName, Exception? exception) => EntitySaveFailedExecute(logger, entityName, exception);

    public static void EntitySaveFailed(this ILogger logger, string entityName, string url, Exception? exception) => EntitySaveFailedExecute(logger, entityName + $". URL:{url}", exception);

    private static readonly Action<ILogger, string, Exception?> EntityUpdateFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntityUpdateFaildedId,
            "TEntity update error: {entityName}");

    public static void EntityUpdateFailed(this ILogger logger, string entityName, Exception? exception) => EntityUpdateFailedExecute(logger, entityName, exception);

    private static readonly Action<ILogger, string, Exception?> EntityDeleteFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntityDeleteFailedId,
            "Error when deleting the entity: {entityName}");

    public static void EntityDeleteFailed(this ILogger logger, string entityName, Exception? exception) => EntityDeleteFailedExecute(logger, entityName, exception);

    private static readonly Action<ILogger, string, Exception?> EntityReadFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntityReadFailedId,
            "Error when reading the entity: {entityName}");

    public static void EntityReadFailed(this ILogger logger, string entityName, Exception? exception) => EntityReadFailedExecute(logger, entityName, exception);
}