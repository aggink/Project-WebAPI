using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Company.WPF.Infrastructure.Services.Base;

public abstract class BaseHttpClient
{
    protected readonly IConfiguration _Configuration;
    protected readonly HttpClient _Client;
    protected readonly string _BaseUrl;
    protected readonly string _MediaType = "application/json";

    public BaseHttpClient(IConfiguration configuration)
    {
        _Configuration = configuration;
        _BaseUrl = configuration["WebService"];
        _Client = new HttpClient()
        {
            BaseAddress = new Uri(_BaseUrl)
        };
    }

    #region Error Message

    /// <summary>
    /// Ошибки при выполнении запросов
    /// </summary>
    public List<string> Errors { get; private set; } = new();

    protected const string __RequestError = "Произошла ошибка входе выполнения запроса к серверу.";
    protected const string __ServerSideError = "Произошла ошибка в ходе выполнения запроса на стороне сервера.";

    #endregion

    /// <summary>
    /// Создание ресурса
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    protected async Task<bool> PostRequestAsync(string url, object data)
    {
        try
        {
            HttpClientSetting(url);
            var response = await _Client.PostAsJsonAsync(url, data);
            if(response.IsSuccessStatusCode) return true;

            return false;
        }
        catch (Exception ex)
        {
            Errors.Add(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Обновление ресурса
    /// </summary>
    /// <param name="url"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    protected async Task<bool> PutRequestAsync(string url, object data)
    {
        try
        {
            HttpClientSetting(url);
            var response = await _Client.PutAsJsonAsync(url, data);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }
        catch (Exception ex)
        {
            Errors.Add(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Удаление ресурса
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    protected async Task<bool> DeleteRequestAsync(string url)
    {
        try
        {
            HttpClientSetting(url);
            var response = await _Client.DeleteAsync(url);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }
        catch (Exception ex)
        {
            Errors.Add(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Получение ресурса
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <returns></returns>
    protected async Task<T?> GetRequestAsync<T>(string url)
    {
        try
        {
            HttpClientSetting(url);
            var response = await _Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }

            return default;
        }
        catch (Exception ex)
        {
            Errors.Add(ex.Message);
            return default;
        }
    }

    private void HttpClientSetting(string url)
    {
        Errors.Clear();

        _Client.DefaultRequestHeaders.Accept.Clear();
        _Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(_MediaType));
    }
}