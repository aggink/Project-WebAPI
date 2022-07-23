using Company.WPF.ViewModels.Base;

namespace Company.WPF.ViewModels;

/// <summary>
/// ViewModel главного окна программы
/// </summary>
public class MainWindowViewModel : ViewModel
{
    public WorkParserViewModel SettingParser { get; }
    public MainWindowViewModel(WorkParserViewModel settingParser)
    {
        SettingParser = settingParser;
    }

    #region Заголовок окна

    private string _Title = "Компания";

    public string Title
    {
        get => _Title;
        set => Set(ref _Title, value);
    }

    #endregion

    #region Команды



    #endregion
}
