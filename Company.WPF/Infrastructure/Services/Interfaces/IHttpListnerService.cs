using Company.WPF.Models.ParserModels;
using Company.WPF.Models.Product;
using Company.WPF.Models.Products;

namespace Company.WPF.Infrastructure.Services.Interfaces;

public interface IHttpListnerService
{
    List<string> Errors { get; }

    /// <summary>
    /// Создать ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> PropertyParserPOSTAsync(PropertyParser model);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> PropertyParserPUTAsync(PropertyParser model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> PropertyParserDELETEAsync(Guid id);

    /// <summary>
    /// Получить все ресурсы
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<PropertyParser>?> ALLPropertyParserGETAsync();

    /// <summary>
    /// Получить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PropertyParser?> PropertyParserGETAsync(Guid id);

    /// <summary>
    /// Добавить ресурсы
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    Task<bool> FieldParserPOSTAsync(IEnumerable<FieldParser> models);

    /// <summary>
    /// Добавить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> FieldParserPOSTAsync(FieldParser model);

    /// <summary>
    /// Обновить ресурсы
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    Task<bool> FieldParserPUTAsync(IEnumerable<FieldParser> models);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> FieldParserPUTAsync(FieldParser model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> FieldParserDELETEAsync(Guid id);

    /// <summary>
    /// Получить все ресурсы относыщийся к одной настройке парсера
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns></returns>
    Task<IEnumerable<FieldParser>?> FieldParserGETAsync(Guid propertyId);

    /// <summary>
    /// Получить все ресурсы
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<WorkParser>?> AllWorkGETAsync();

    /// <summary>
    /// Добавить ресурс
    /// </summary>
    /// <param name="propertyId"></param>
    /// <returns></returns>
    Task<bool> AddWorkPOSTAsync(Guid propertyId);

    /// <summary>
    /// Получить список ресурсов
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<DataProduct<BulatProduct>?> BulatProductGETAsync(int pageIndex, int pageSize);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> BulatProductPUTAsync(BulatProduct model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> BulatProductDELETEAsync(Guid id);

    /// <summary>
    /// Получить список ресурсов
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<DataProduct<RamisProduct>?> RamisProductGETAsync(int pageIndex, int pageSize);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> RamisProductPUTAsync(RamisProduct model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> RamisProductDELETEAsync(Guid id);

    /// <summary>
    /// Получить список ресурсов
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<DataProduct<ChipCartProduct>?> ChipCartProductGETAsync(int pageIndex, int pageSize);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> ChipCartProductPUTAsync(ChipCartProduct model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ChipCartProductDELETEAsync(Guid id);

    /// <summary>
    /// Обновить ресурс
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<bool> ZipZipProductPUTAsync(ZipZipProduct model);

    /// <summary>
    /// Удалить ресурс
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> ZipZipProductDELETEAsync(Guid id);

    /// <summary>
    /// Получить список ресурсов
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<DataProduct<ZipZipProduct>?> ZipZipProductGETAsync(int pageIndex, int pageSize);
}