using Company.WPF.Infrastructure.Commands.Base;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.ParserModels;
using Company.WPF.ViewModels.Base;
using Company.WPF.ViewModels.Base.Interfaces;
using Company.WPF.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace Company.WPF.ViewModels.Windows;

/// <summary>
/// ViewModel по созданию/обновлению данных о полях парсинга 
/// </summary>
public class CreateOrUpdateFieldParserViewModel : ViewModel
{
    private readonly Window ActiveWindow = Application.Current.Windows.OfType<CreateOrUpdateFieldParserWindow>().First();

    private readonly IHttpListnerService _HttpListnerService;
    private readonly IUserDialogService _UserDialogService;
    private readonly IMessenger _Messager;

    public CreateOrUpdateFieldParserViewModel(
        IHttpListnerService HttpListnerService, 
        IUserDialogService UserDialogService,
        IMessenger Messenger)
    {
        _HttpListnerService = HttpListnerService;
        _UserDialogService = UserDialogService;
        _Messager = Messenger;

        _Messager.Register<FieldParserForViewModel>(SetData);
    }

    private Guid Id { get; set; }
    private Guid PropertyParserId { get; set; }

    #region Заголовок окна

    private string _Title = "Добавление/обновление данных";

    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    #region Список элементов

    private IEnumerable<string>? _NameProperties;
    public IEnumerable<string>? NameProperties { get => _NameProperties; set => Set(ref _NameProperties, value); }

    #endregion

    #region Выбранный элемент

    private string? _SelectedNameProperty;
    public string? SelectedNameProperty { get => _SelectedNameProperty; set => Set(ref _SelectedNameProperty, value); }

    #endregion

    #region Значение по умолчанию

    private string? _DefaultValue;
    public string? DefaultValue { get => _DefaultValue; set => Set(ref _DefaultValue, value); }

    #endregion

    #region CSS селектор

    private string? _StringParse;
    public string? StringParse { get => _StringParse; set => Set(ref _StringParse, value); }

    #endregion

    #region Команда сохранить/обновить значения

    private ICommand? _CreateOrUpdateCommandExecute;

    public ICommand CreateOrUpdateCommandExecute => _CreateOrUpdateCommandExecute ??= new LambdaCommand(OnCreateOrUpdateCommandExecute, CanCreateOrUpdateCommandExecute);

    private bool CanCreateOrUpdateCommandExecute(object? p)
    {
        if (PropertyParserId == Guid.Empty) return false;
        if (string.IsNullOrWhiteSpace(_SelectedNameProperty)) return false;
        if (string.IsNullOrWhiteSpace(_DefaultValue)) return false;
        if (string.IsNullOrEmpty(_StringParse)) return false;

        return true;
    }

    private async void OnCreateOrUpdateCommandExecute(object? p)
    {
        var entity = new FieldParser()
        {
            Id = Id,
            PropertyParserId = PropertyParserId,
            NameProperty = _SelectedNameProperty,
            DefaultValue = _DefaultValue,
            StringParse = _StringParse
        };

        bool result;
        if (Id == Guid.Empty) result = await _HttpListnerService.FieldParserPOSTAsync(entity);
        else result = await _HttpListnerService.FieldParserPUTAsync(entity);

        if (result)
        {
            _UserDialogService.ShowInformation("Данные успешно сохранены", Title);
            ActiveWindow.Close();
        }
        else _UserDialogService.ShowError("Ошибка при сохранении данных", Title);
    }

    #endregion

    #region Команда закрытия окна

    private ICommand? _CloseWindowCommandExecute;

    public ICommand CloseWindowCommandExecute => _CloseWindowCommandExecute ??= new LambdaCommand(OnCloseWindowCommandExecute);

    private void OnCloseWindowCommandExecute(object? p) => ActiveWindow.Close();

    #endregion

    #region Команда - действия при закрытии окна

    private ICommand? _CloseWindowActionsCommandExecute;

    public ICommand CloseWindowActionsCommandExecute => _CloseWindowActionsCommandExecute ??= new LambdaCommand(OnCloseWindowActionsCommandExecute);

    private void OnCloseWindowActionsCommandExecute(object? p)
    {
        _Messager.Unregister<FieldParserForViewModel>(SetData);
    }

    #endregion

    /// <summary>
    /// Заполнение полей формы
    /// </summary>
    /// <param name="data"></param>
    private void SetData(object data)
    {
        if (data is FieldParserForViewModel model)
        {
            Id = model.Id;
            PropertyParserId = model.PropertyParserId;
            DefaultValue = model.DefaultValue;
            StringParse = model.StringParse;
            NameProperties = model.AllNameProperties;

            if (model.NameProperty != null)
                SelectedNameProperty = _NameProperties!.First(x => x.Contains(model.NameProperty));
        }
    }
}