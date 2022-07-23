namespace Company.WebAPI.Infrastructure.EventLogging;

/// <summary>
/// Microsoft ILogger system helper
/// </summary>
public static partial class Events
{
    #region EventIdentifiers

    private static readonly EventId EntitySaveFailedId = new(70040001, "EntitySavingFailed");
    private static readonly EventId EntityUpdateFaildedId = new(70040002, "EntityUpdateFailed");
    private static readonly EventId EntityDeleteFailedId = new(70040003, "EntityDeleteFailed");
    private static readonly EventId EntityReadFailedId = new(70040004, "EntityReadFailed");

    private static readonly EventId BackgroundWorkCreatedId = new(10010001, "BackgroundWorkCreated");
    private static readonly EventId BackgroundWorkCompletedId = new(10010002, "BackgroundWorkCompleted");
    private static readonly EventId BackgroundWorkFailedId = new(10010003, "BackgroundWorkFailed");

    #endregion

    #region Entity Logger

    private static readonly Action<ILogger, string, Exception?> EntitySaveFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntitySaveFailedId,
            "Entity creation error: {entityName}");

    public static void EntitySaveFailed(this ILogger logger, string entityName, Exception? exception) => EntitySaveFailedExecute(logger, entityName, exception);

    public static void EntitySaveFailed(this ILogger logger, string entityName, string url, Exception? exception) => EntitySaveFailedExecute(logger, entityName + $". URL:{url}", exception);

    private static readonly Action<ILogger, string, Exception?> EntityUpdateFailedExecute =
        LoggerMessage.Define<string>(
            LogLevel.Critical,
            EntityUpdateFaildedId,
            "Entity update error: {entityName}");

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

    #endregion

    #region Background Logger

    private static readonly Action<ILogger, string, string, Exception?> BackgroundWorkCreatedExecute =
        LoggerMessage.Define<string, string>(
            LogLevel.Information,
            BackgroundWorkCreatedId,
            "The background task ({workType}) with id = {id} is running.");

    public static void BackgroundWorkCreated(this ILogger logger, string workType, string id, Exception? exception = null) => BackgroundWorkCreatedExecute(logger, workType, id, exception);

    private static readonly Action<ILogger, string, string, Exception?> BackgroundWorkComletedExecute =
        LoggerMessage.Define<string, string>(
        LogLevel.Information,
        BackgroundWorkCompletedId,
        "The background task ({workType}) with id = {id} has completed.");

    public static void BackgroundWorkComleted(this ILogger logger, string workType, string id, Exception? exception = null) => BackgroundWorkComletedExecute(logger, workType, id, exception);

    private static readonly Action<ILogger, string, string, Exception?> BackgroundWorkFailedExecute =
        LoggerMessage.Define<string, string>(
        LogLevel.Critical,
        BackgroundWorkFailedId,
        "An error occurred while executing a background task ({workType}) with id = {id}.");

    public static void BackgroundWorkFailed(this ILogger logger, string workType, string id, Exception? exception) => BackgroundWorkComletedExecute(logger, workType, id, exception);

    #endregion
}