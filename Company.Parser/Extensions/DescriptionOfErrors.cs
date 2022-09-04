namespace Company.Parser.Extensions;

public static class DescriptionOfErrors
{
    /// <summary>
    /// Получить сообщение об ошибке.
    /// </summary>
    /// <param name="ex">Ошибка.</param>
    /// <returns>Сообщение об ошибке.</returns>
    public static string GetExeption(Exception ex)
    {
        string message = $"Message: {ex.Message}.\n";
        if (ex.HelpLink != null) message += $"HelpLink: {ex.HelpLink}.\n";
        if (ex.Source != null) message += $"Sourse: {ex.Source}.\n";
        if (ex.StackTrace != null) message += $"StackTrace: \n{ex.StackTrace}.\n";
        if (ex.TargetSite != null) message += $"TargetSite: {ex.TargetSite}.\n";
        if (ex.InnerException != null) message += $"InnerException: {GetExeption(ex.InnerException)}.\n";
        return message;
    }
}