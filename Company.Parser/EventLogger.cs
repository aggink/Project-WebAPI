using Microsoft.Extensions.Logging;

namespace Company.Parser;

public static class EventLogger
{
    #region EventIdentifiers

    private static readonly EventId BackgroundWorkCreatedId = new(10010001, "BackgroundWorkCreated");
    private static readonly EventId BackgroundWorkCompletedId = new(10010002, "BackgroundWorkCompleted");
    private static readonly EventId BackgroundWorkFailedId = new(10010003, "BackgroundWorkFailed");

    private static readonly EventId ParserResultHandlerFailedId = new(10010001, "An error occurred in the parser result handler.");

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

    public static void BackgroundWorkFailed(this ILogger logger, string workType, string id, Exception? exception) => BackgroundWorkFailedExecute(logger, workType, id, exception);

    #endregion

    private static readonly Action<ILogger, string, string, Exception?> ParserResultHandlerExecute =
        LoggerMessage.Define<string, string>(
        LogLevel.Critical,
        ParserResultHandlerFailedId,
        "An error occurred while processing received values ​​from web resource parsing. Common group ID = {groupId}. Parser ID = {ParserId}");

    public static void ParserResultHandlerFailed(this ILogger logger, string parserId, string groupId, Exception? exception) => ParserResultHandlerExecute(logger, parserId, groupId, exception);
}