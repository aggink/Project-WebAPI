namespace Company.Parser.Extensions;

/// <summary>
///Различные проверки
/// </summary>
public static class ValidatorExtension
{
    /// <summary>
    /// Проверить правильность записи url-адреса
    /// </summary>
    /// <param name="url"></param>
    /// <returns>True - url-адрес записан верно. Flase - ошибка в написании url-адреса.</returns>
    public static bool CheckURLValid(string url)
    {
        try
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp))
            {
                return true;
            }
        }
        catch { return false; }

        return false;
    }
}