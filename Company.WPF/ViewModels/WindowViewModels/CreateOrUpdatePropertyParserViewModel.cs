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
/// ViewModel по созданию/обновлению данных парсера
/// </summary>
public class CreateOrUpdatePropertyParserViewModel : ViewModel
{
    private readonly Window ActiveWindow = Application.Current.Windows.OfType<CreateOrUpdatePropertyParserWindow>().First();

    private readonly IHttpListnerService _HttpListnerService;
    private readonly IUserDialogService _UserDialogService;
    private readonly IMessenger _Messager;

    public CreateOrUpdatePropertyParserViewModel(
        IHttpListnerService HttpListnerService,
        IUserDialogService UserDialogService,
        IMessenger Messenger)
    {
        _HttpListnerService = HttpListnerService;
        _UserDialogService = UserDialogService;
        _Messager = Messenger;

        _Messager.Register<PropertyParserForViewModel>(SetData);
    }

    private Guid Id { get; set; }

    #region Заголовок окна

    private string _Title = "Добавление/обновление данных";

    public string Title { get => _Title; set => Set(ref _Title, value); }

    #endregion

    #region Веб-адрес сайта

    private string? _URL;
    public string? URL { get => _URL; set => Set(ref _URL, value); }

    #endregion

    #region Название сайта

    private string? _NameSite;
    public string? NameSite { get => _NameSite; set => Set(ref _NameSite, value); }

    #endregion

    #region Название компании

    private string? _NameCompany;
    public string? NameCompany { get => _NameCompany; set => Set(ref _NameCompany, value); }

    #endregion

    #region Описание компании

    private string? _DescriptionCompany;
    public string? DescriptionCompany { get => _DescriptionCompany; set => Set(ref _DescriptionCompany, value); }

    #endregion

    #region Список площадок

    private IEnumerable<string>? _NameTypes;
    public IEnumerable<string>? NameTypes { get => _NameTypes; set => Set(ref _NameTypes, value); }

    #endregion

    #region Выбранная площадка

    private string? _SelectedNameType;
    public string? SelectedNameType { get => _SelectedNameType; set => Set(ref _SelectedNameType, value); }

    #endregion

    #region Команда сохранить/обновить значения

    private ICommand? _CreateOrUpdateCommandExecute;

    public ICommand CreateOrUpdateCommandExecute => _CreateOrUpdateCommandExecute ??= new LambdaCommand(OnCreateOrUpdateCommandExecute, CanCreateOrUpdateCommandExecute);

    private bool CanCreateOrUpdateCommandExecute(object? p)
    {
        if (string.IsNullOrWhiteSpace(_URL)) return false;
        if (string.IsNullOrWhiteSpace(_NameSite)) return false;
        if (string.IsNullOrEmpty(_NameCompany)) return false;
        if (string.IsNullOrEmpty(_DescriptionCompany)) return false;
        if (string.IsNullOrEmpty(_SelectedNameType)) return false;

        return true;
    }

    private async void OnCreateOrUpdateCommandExecute(object? p)
    {
        var entity = new PropertyParser()
        {
            Id = Id,
            URL = _URL,
            NameSite = _NameSite,
            NameCompany = _NameCompany,
            DescriptionCompany = _DescriptionCompany,
            NameType = _SelectedNameType
        };

        bool result;
        if (Id == Guid.Empty) result = await _HttpListnerService.PropertyParserPOSTAsync(entity);
        else result = await _HttpListnerService.PropertyParserPUTAsync(entity);

        if (result)
        {
            _UserDialogService.ShowInformation("Данные успешно сохранены", Title);
            ActiveWindow.Close();
        }
        else _UserDialogService.ShowError("Ошибка при сохранении данных", Title);
    }

    #endregion

    #region Команда назад

    private ICommand? _CloseWindowCommandExecute;

    public ICommand CloseWindowCommandExecute => _CloseWindowCommandExecute ??= new LambdaCommand(OnCloseWindowCommandExecute);
    
    private void OnCloseWindowCommandExecute(object? p) => ActiveWindow.Close();

    #endregion

    #region Команда - действия при закрытии окна

    private ICommand? _CloseWindowActionsCommandExecute;

    public ICommand CloseWindowActionsCommandExecute => _CloseWindowActionsCommandExecute ??= new LambdaCommand(OnCloseWindowActionsCommandExecute);

    private void OnCloseWindowActionsCommandExecute(object? p)
    {
        _Messager.Unregister<PropertyParserForViewModel>(SetData);
    }

    #endregion

    /// <summary>
    /// Заполнение полей формы
    /// </summary>
    /// <param name="data"></param>
    private void SetData(object data)
    {
        if(data is PropertyParserForViewModel model)
        {
            Id = model.Id;
            NameSite = model.NameSite;
            URL = model.URL;
            NameCompany = model.NameCompany;
            DescriptionCompany = model.DescriptionCompany;
            NameTypes = model.AllNameTypes;

            if(model.NameType != null)
                SelectedNameType = _NameTypes!.First(x => x.Contains(model.NameType));
        }
    }
}