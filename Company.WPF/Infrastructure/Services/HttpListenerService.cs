using Company.WPF.Infrastructure.Services.Base;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.ParserModels;
using Company.WPF.Models.Product;
using Company.WPF.Models.Products;
using Microsoft.Extensions.Configuration;

namespace Company.WPF.Infrastructure.Services;

/// <summary>
/// Отправка запросов / получение ответов от сервера
/// </summary>
public class HttpListnerService : BaseHttpClient, IHttpListnerService
{
    public HttpListnerService(IConfiguration configuration)
        : base(configuration)
    {
        _PostPropertyURL = _BaseUrl + "parser/setting";
        _PutPropertyURL = _BaseUrl + "parser/setting";
        _GetAllPropertiesURL = _BaseUrl + "parser/get";
        _DeletePropertyURL = _BaseUrl + "parser/delete/";
        _GetPropertyURL = _BaseUrl + "parser/setting/";

        _PostFieldsURL = _BaseUrl + "parser/localsetting";
        _PutFieldsURL = _BaseUrl + "parser/localsetting";
        _GetFieldsURL = _BaseUrl + "parser/localsetting/";
        _DeleteFieldURL = _BaseUrl + "parser/localsetting/delete/";

        _GetAllWorkURL = _BaseUrl + "parser/work";
        _AddWorkURL = _BaseUrl + "parser/work/";

        _GetBulatURL = _BaseUrl + "";
        _PutBulatURL = _BaseUrl + "";
        _DeleteBulatURL = _BaseUrl + "";
        _GetPageBulatURL = _BaseUrl + "?pageindex={pageindex}&pagesize={pagesize}";

        _GetRamisURL = _BaseUrl + "";
        _PutRamisURL = _BaseUrl + "";
        _DeleteRamisURL = _BaseUrl + "";
        _GetPageRamisURL = _BaseUrl + "?pageindex={pageindex}&pagesize={pagesize}";

        _GetChipCartURL = _BaseUrl + "";
        _PutChipCartURL = _BaseUrl + "";
        _DeleteChipCartURL = _BaseUrl + "";
        _GetPageChipCartURL = _BaseUrl + "?pageindex={pageindex}&pagesize={pagesize}";

        _GetZipZipURL = _BaseUrl + "";
        _PutZipZipURL = _BaseUrl + "";
        _DeleteZipZipURL = _BaseUrl + "";
        _GetPageZipZipURL = _BaseUrl + "?pageindex={pageindex}&pagesize={pagesize}";
    }

    #region Property Parser

    private readonly string _PostPropertyURL;
    private readonly string _DeletePropertyURL;
    private readonly string _PutPropertyURL;
    private readonly string _GetAllPropertiesURL;
    private readonly string _GetPropertyURL;

    public async Task<bool> PropertyParserPOSTAsync(PropertyParser model)
    {
        if(model == null) throw new ArgumentNullException(nameof(model));

        var response = await PostRequestAsync(_PostPropertyURL, new
        {
            url = model.URL,
            name_site = model.NameSite,
            company_name = model.NameCompany,
            company_description = model.DescriptionCompany,
            type_name = model.NameType
        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> PropertyParserPUTAsync(PropertyParser model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutPropertyURL, new
        {
            id = model.Id,
            url = model.URL,
            name_site = model.NameSite,
            company_name = model.NameCompany,
            company_description = model.DescriptionCompany,
            type_name = model.NameType
        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> PropertyParserDELETEAsync(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeletePropertyURL + id);
        if (!response) return false;
        return true;
    }

    public async Task<IEnumerable<PropertyParser>?> ALLPropertyParserGETAsync()
    {
        var response = await GetRequestAsync<List<PropertyParser>>(_GetAllPropertiesURL);
        if (response == null) return null;
        return response;
    }

    public async Task<PropertyParser?> PropertyParserGETAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await GetRequestAsync<PropertyParser>(_GetPropertyURL + id);
        if (response == null) return null;
        return response;
    }

    #endregion

    #region Fields Parser

    private readonly string _PostFieldsURL;
    private readonly string _PutFieldsURL;
    private readonly string _GetFieldsURL;
    private readonly string _DeleteFieldURL;

    public async Task<bool> FieldParserPOSTAsync(IEnumerable<FieldParser> models)
    {
        if (models == null || !models.Any()) throw new ArgumentNullException(nameof(models));

        var response = await PostRequestAsync(_PostFieldsURL, models.Select(x => new
        {
            property_parser_id = x.PropertyParserId,
            property_name = x.NameProperty,
            default_value = x.DefaultValue,
            string_parse = x.StringParse
        }));

        if (!response) return false;
        return true;
    }

    public async Task<bool> FieldParserPOSTAsync(FieldParser model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PostRequestAsync(_PostFieldsURL, new
        {
            property_parser_id = model.PropertyParserId,
            property_name = model.NameProperty,
            default_value = model.DefaultValue,
            string_parse = model.StringParse
        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> FieldParserPUTAsync(IEnumerable<FieldParser> models)
    {
        if (models == null || !models.Any()) throw new ArgumentNullException(nameof(models));

        var response = await PutRequestAsync(_PutFieldsURL, models.Select(x => new
        {
            id = x.Id,
            property_parser_id = x.PropertyParserId,
            property_name = x.NameProperty,
            default_value = x.DefaultValue,
            string_parse = x.StringParse
        }));

        if (!response) return false;
        return true;
    }

    public async Task<bool> FieldParserPUTAsync(FieldParser model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutFieldsURL, new
        {
            id = model.Id,
            property_parser_id = model.PropertyParserId,
            property_name = model.NameProperty,
            default_value = model.DefaultValue,
            string_parse = model.StringParse
        });

        if (!response) return false;
        return true;
    }

    public async Task<IEnumerable<FieldParser>?> FieldParserGETAsync(Guid propertyId)
    {
        if (propertyId == Guid.Empty) throw new ArgumentNullException(nameof(propertyId));

        var response = await GetRequestAsync<IEnumerable<FieldParser>>(_GetFieldsURL + propertyId);
        if (response == null) return null;
        return response;
    }

    public async Task<bool> FieldParserDELETEAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeleteFieldURL + id);
        if (!response) return false;
        return true;
    }

    #endregion

    #region Work Parser

    private readonly string _GetAllWorkURL;
    private readonly string _AddWorkURL;

    public async Task<IEnumerable<WorkParser>?> AllWorkGETAsync()
    {
        var response = await GetRequestAsync<IEnumerable<WorkParser>>(_GetAllWorkURL);
        if (response == null) return null;
        return response;
    }

    public async Task<bool> AddWorkPOSTAsync(Guid propertyId)
    {
        if (propertyId == Guid.Empty) throw new ArgumentNullException(nameof(propertyId));

        var response = await PostRequestAsync(_AddWorkURL, propertyId);
        if (!response) return false;
        return true;
    }

    #endregion

    private const string _PageSize = "{pagesize}";
    private const string _PageIndex = "{pageindex}";

    #region BulatProduct

    private readonly string _GetBulatURL;
    private readonly string _PutBulatURL;
    private readonly string _DeleteBulatURL;
    private readonly string _GetPageBulatURL;

    public async Task<bool> BulatProductPUTAsync(BulatProduct model)
    {
        if(model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutBulatURL, new
        {

        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> BulatProductDELETEAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeleteBulatURL + id);
        if (!response) return false;
        return true;
    }

    public async Task<DataProduct<BulatProduct>?> BulatProductGETAsync(int pageIndex, int pageSize)
    {
        if(pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if(pageIndex <= 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));

        var response = await GetRequestAsync<DataProduct<BulatProduct>>(
            _GetPageBulatURL.Replace(_PageSize, pageSize.ToString())
            .Replace(_PageIndex, pageIndex.ToString()));
        if(response == null) return null;
        return response;
    }

    #endregion

    #region RamisProduct

    private readonly string _GetRamisURL;
    private readonly string _PutRamisURL;
    private readonly string _DeleteRamisURL;
    private readonly string _GetPageRamisURL;

    public async Task<bool> RamisProductPUTAsync(RamisProduct model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutRamisURL, new
        {

        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> RamisProductDELETEAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeleteRamisURL + id);
        if (!response) return false;
        return true;
    }

    public async Task<DataProduct<RamisProduct>?> RamisProductGETAsync(int pageIndex, int pageSize)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageIndex <= 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));

        var response = await GetRequestAsync<DataProduct<RamisProduct>>(
            _GetPageRamisURL.Replace(_PageSize, pageSize.ToString())
            .Replace(_PageIndex, pageIndex.ToString()));
        if (response == null) return null;
        return response;
    }

    #endregion

    #region ChipCartProduct

    private readonly string _GetChipCartURL;
    private readonly string _PutChipCartURL;
    private readonly string _DeleteChipCartURL;
    private readonly string _GetPageChipCartURL;

    public async Task<bool> ChipCartProductPUTAsync(ChipCartProduct model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutChipCartURL, new
        {

        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> ChipCartProductDELETEAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeleteChipCartURL + id);
        if (!response) return false;
        return true;
    }

    public async Task<DataProduct<ChipCartProduct>?> ChipCartProductGETAsync(int pageIndex, int pageSize)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageIndex <= 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));

        var response = await GetRequestAsync<DataProduct<ChipCartProduct>>(
            _GetPageChipCartURL.Replace(_PageSize, pageSize.ToString())
            .Replace(_PageIndex, pageIndex.ToString()));
        if (response == null) return null;
        return response;
    }

    #endregion

    #region ZipZipProduct

    private readonly string _GetZipZipURL;
    private readonly string _PutZipZipURL;
    private readonly string _DeleteZipZipURL;
    private readonly string _GetPageZipZipURL;

    public async Task<bool> ZipZipProductPUTAsync(ZipZipProduct model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var response = await PutRequestAsync(_PutZipZipURL, new
        {

        });

        if (!response) return false;
        return true;
    }

    public async Task<bool> ZipZipProductDELETEAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        var response = await DeleteRequestAsync(_DeleteZipZipURL + id);
        if (!response) return false;
        return true;
    }

    public async Task<DataProduct<ZipZipProduct>?> ZipZipProductGETAsync(int pageIndex, int pageSize)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageIndex <= 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));

        var response = await GetRequestAsync<DataProduct<ZipZipProduct>>(
            _GetPageZipZipURL.Replace(_PageSize, pageSize.ToString())
            .Replace(_PageIndex, pageIndex.ToString()));
        if (response == null) return null;
        return response;
    }

    #endregion
}