using Company.WPF.Infrastructure.Commands.Base;
using Company.WPF.Infrastructure.Extensions;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.ParserModels;
using Company.WPF.ViewModels.Base;
using Company.WPF.ViewModels.Base.Interfaces;
using Company.WPF.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace Company.WPF.ViewModels;

/// <summary>
/// ViewModel по просмотру/настроки парсера сайтов
/// </summary>
public class PropertyParserViewModel : ViewModel
{
    private static Window ActiveWindow => Application.Current.Windows.OfType<MainWindow>().First();

    private readonly IHttpListnerService _HttpListnerService;
    private readonly IUserDialogService _UserDialogService;
    private readonly IMessenger _Messenger;

    public PropertyParserViewModel(
        IHttpListnerService HttpListnerService,
        IUserDialogService UserDialogService,
        IMessenger Messenger)
    {
        _HttpListnerService = HttpListnerService;
        _UserDialogService = UserDialogService;
        _Messenger = Messenger;

        CanDownloadPropertyParserCommandExecute(null);
    }

    #region Настройки парсера

    private IEnumerable<PropertyParser>? _PropertiesParser;

    public IEnumerable<PropertyParser>? PropertiesParser { get => _PropertiesParser; set => Set(ref _PropertiesParser, value); }

    #endregion

    #region Выбранная настройка

    private PropertyParser? _SelectedPropertyParser;

    public PropertyParser? SelectedPropertyParser { get => _SelectedPropertyParser; set => Set(ref _SelectedPropertyParser, value); }

    #endregion

    #region Выбранный параметр парсера

    private FieldParser? _SelectedParserParam;

    public FieldParser? SelectedParserParam { get => _SelectedParserParam; set => Set(ref _SelectedParserParam, value); }

    #endregion

    #region Команда добавления настройки парсера

    private ICommand? _AddPropertyParserCommandExecute;

    public ICommand AddPropertyParserCommandExecute => 
        _AddPropertyParserCommandExecute ??= new LambdaCommand(
            OnAddPropertyParserCommandExecute);

    private void OnAddPropertyParserCommandExecute(object? p)
    {
        var window = new CreateOrUpdatePropertyParserWindow()
        {
            Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        _Messenger.Send(new PropertyParserForViewModel()
        {
            AllNameTypes = GetNameTypes()
        });

        window.ShowDialog();

        CanDownloadPropertyParserCommandExecute(null);
    }

    #endregion

    #region Команда удалении настройки парсера

    private ICommand? _DeletePropertyParserCommandExecute;

    public ICommand DeletePropertyParserCommandExecute => 
        _DeletePropertyParserCommandExecute ??= new LambdaCommand(
            OnDeletePropertyParserCommandExecute, 
            CanDeletePropertyParserCommandExecute);

    private bool CanDeletePropertyParserCommandExecute(object? p)
    {
        if (_SelectedPropertyParser == null) return false;
        return true;
    }

    private async void OnDeletePropertyParserCommandExecute(object? p)
    {
        var result = await _HttpListnerService.PropertyParserDELETEAsync(_SelectedPropertyParser!.Id);
        if (result) 
            CanDownloadPropertyParserCommandExecute(null);
        else
            _UserDialogService.ShowError("Ошибка при удалении записи. Запись не удалена", "Ошибка");
    }

    #endregion

    #region Команда редактирования настройки парсера

    private ICommand? _UpdatePropertyParserCommandExecute;

    public ICommand UpdatePropertyParserCommandExecute => 
        _UpdatePropertyParserCommandExecute ??= new LambdaCommand(
            OnUpdatePropertyParserCommandExecute, 
            CanUpdatePropertyParserCommandExecute);

    private bool CanUpdatePropertyParserCommandExecute(object? p)
    {
        if(_SelectedPropertyParser == null) return false;
        return true;
    }

    private void OnUpdatePropertyParserCommandExecute(object? p)
    {
        var window = new CreateOrUpdatePropertyParserWindow()
        {
            Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        _Messenger.Send(new PropertyParserForViewModel(_SelectedPropertyParser)
        {
            AllNameTypes = GetNameTypes(),
        });

        window.ShowDialog();
        CanDownloadPropertyParserCommandExecute(null);
    }

    #endregion

    #region Команда добавления поля парсера

    private ICommand? _AddFieldParserCommandExecute;

    public ICommand AddFieldParserCommandExecute => 
        _AddFieldParserCommandExecute ??= new LambdaCommand(
            OnAddFieldParserCommandExecute, 
            CanAddFieldParserCommandExecute);

    private bool CanAddFieldParserCommandExecute(object? p)
    {
        if(SelectedPropertyParser == null) return false;
        return true;
    }

    private void OnAddFieldParserCommandExecute(object? p)
    {
        var window = new CreateOrUpdateFieldParserWindow()
        {
            Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        _Messenger.Send(new FieldParserForViewModel()
        {
            PropertyParserId = SelectedPropertyParser!.Id,
            AllNameProperties = GetNameProperties(SelectedPropertyParser.NameType)
        });

        window.ShowDialog();
        CanDownloadPropertyParserCommandExecute(null);
    }

    #endregion

    #region Команда редактирования поля парсера

    private ICommand? _UpdateFieldParserCommandExecute;

    public ICommand UpdateFieldParserCommandExecute => 
        _UpdateFieldParserCommandExecute ??= new LambdaCommand(
            OnUpdateFieldParserCommandExecute, 
            CanUpdateFieldParserCommandExecute);

    private bool CanUpdateFieldParserCommandExecute(object? p)
    {
        if(SelectedParserParam == null) return false;
        return true;
    }

    private void OnUpdateFieldParserCommandExecute(object? p)
    {
        var window = new CreateOrUpdateFieldParserWindow()
        {
            Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        _Messenger.Send(new FieldParserForViewModel(SelectedParserParam)
        {
            AllNameProperties = GetNameProperties(SelectedPropertyParser!.NameType)
        });

        window.ShowDialog();
        CanDownloadPropertyParserCommandExecute(null);
    }

    #endregion

    #region Команда удалении поля парсера

    private ICommand? _DeleteFieldParserCommandExecute;

    public ICommand DeleteFieldParserCommandExecute => 
        _DeleteFieldParserCommandExecute ??= new LambdaCommand(
            OnDeleteFieldParserCommandExecute, 
            CanDeleteFieldParserCommandExecute);

    private bool CanDeleteFieldParserCommandExecute(object? p)
    {
        if (SelectedParserParam == null) return true;
        return true;
    }

    private async void OnDeleteFieldParserCommandExecute(object? p)
    {
        var result = await _HttpListnerService.FieldParserDELETEAsync(SelectedParserParam!.Id);
        if (result)
            CanDownloadPropertyParserCommandExecute(null);
        else
            _UserDialogService.ShowError("Ошибка при удалении записи. Запись не удалена", "Ошибка");
    }

    #endregion

    #region Команда загрузки данных

    private ICommand? _DownloadPropertyParserCommandExecute;

    public ICommand DownloadPropertyParserCommandExecute =>
        _DownloadPropertyParserCommandExecute ??= new LambdaCommand(
            CanDownloadPropertyParserCommandExecute);

    private async void CanDownloadPropertyParserCommandExecute(object? p)
    {
        if (App.IsDesignMode || App.IsDevelopment)
        {
            PropertiesParser = Enumerable.Range(1, 50).Select(x => new PropertyParser()
            {
                Id = Guid.NewGuid(),
                NameCompany = MyRandom.RandomString(MyRandom.RandomInt(15, 50)),
                DescriptionCompany = MyRandom.RandomString(MyRandom.RandomInt(200, 400)),
                NameSite = MyRandom.RandomString(MyRandom.RandomInt(15, 50)),
                NameType = MyRandom.RandomString(MyRandom.RandomInt(5, 10)),
                URL = MyRandom.RandomString(MyRandom.RandomInt(15, 40)),
                ParamsParser = Enumerable.Range(1, MyRandom.RandomInt(10, 30)).Select(y => new FieldParser()
                {
                    Id = Guid.NewGuid(),
                    PropertyParserId = Guid.NewGuid(),
                    NameProperty = MyRandom.RandomString(MyRandom.RandomInt(10, 20)),
                    StringParse = MyRandom.RandomString(MyRandom.RandomInt(100, 200)),
                    DefaultValue = MyRandom.RandomString(MyRandom.RandomInt(100, 200))
                })
            });

            SelectedPropertyParser = PropertiesParser.First();
            SelectedParserParam = SelectedPropertyParser.ParamsParser.First();
        }
        else
        {
            PropertiesParser = await _HttpListnerService.ALLPropertyParserGETAsync();
            SelectedPropertyParser = PropertiesParser?.FirstOrDefault();
            SelectedParserParam = SelectedPropertyParser?.ParamsParser.FirstOrDefault();
        }
    }

    #endregion

    #region Различные методы

    /// <summary>
    /// Получить названия торговых площадок
    /// </summary>
    /// <returns></returns>
    private List<string> GetNameTypes()
    {
        return new List<string>(){
            "BulatProduct",
            "ChipCartProduct",
            "RamisProduct",
            "ZipZipProduct"
        };
    }

    /// <summary>
    /// Получить название полей для задание параметров парсера
    /// </summary>
    /// <param name="nameType"></param>
    /// <returns></returns>
    private List<string> GetNameProperties(string nameType)
    {
        return nameType switch
        {
            "BulatProduct" => new List<string>()
            {
                "URL", "Name", "Manufacturer", "Article", "Weight", "Vendor", 
                "CodeProduct", "Description", "Price", "Availability", "AvailabilityType", 
                "Color", "Compatibility", "LengthWidthHeight", "Model", "AnalogProduct", "Resource", 
                "TypeProduct", "TypeEquipment", "OriginallyProduct", "SeriesProduct", "PriceFrom5", "PriceFrom10"
            },
            "ChipCartProduct" => new List<string>()
            {
                "URL", "Name", "Manufacturer", "Article", "Price", "Availability", "AvailabilityType", "Weight", 
                "Vendor", "CodeProduct", "Description", "Color", "PrinterCompatibility", "CartridgeCompatibility", "TypeProduct"
            },
            "RamisProduct" => new List<string>()
            {
                "URL", "Name", "Manufacturer", "Article", "Weight", "Vendor", "CodeProduct", "Description", 
                "Price", "Availability", "AvailabilityType", "Color", "PrinterCompatibility", "CartridgeCompatibility", "QuantityPackage", "TrademarkAndPN"
            },
            "ZipZipProduct" => new List<string>()
            {
                "URL", "Name", "Manufacturer", "Article", "Compatibility", "Availability", "AvailabilityType", "Price", "OriginallyProduct", "Category"
            },
            _ => new List<string>()
        };
    }

    #endregion
}