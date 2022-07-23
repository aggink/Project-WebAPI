using Company.WPF.Infrastructure.Commands.Base;
using Company.WPF.Infrastructure.Extensions;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.ParserModels;
using Company.WPF.ViewModels.Base;
using Company.WPF.Views;
using System.Windows;
using System.Windows.Input;

namespace Company.WPF.ViewModels;

/// <summary>
/// ViewModel по просмотру сведений о выполняемых/заевершенных/ожидаемых фоновых задачах (парсинг)
/// </summary>
public class WorkParserViewModel : ViewModel
{
    private static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)!;

    private readonly IHttpListnerService _HttpListnerService;
    public WorkParserViewModel(IHttpListnerService listnerService)
    {
        _HttpListnerService = listnerService;

        if (App.IsDesignMode || App.IsDevelopment)
        {
            WorksParser = Enumerable.Range(1, 50).Select(i => new WorkParser()
            {
                CompletionTime = DateTime.Now,
                IsCompleted = false,
                IsStarted = true,
                StartTime = DateTime.Now,
                PropertyParserId = Guid.NewGuid(),
                PropertyParser = new PropertyParser()
                {
                    Id = Guid.NewGuid(),
                    NameCompany = MyRandom.RandomString(MyRandom.RandomInt(15, 50)),
                    DescriptionCompany = MyRandom.RandomString(MyRandom.RandomInt(200, 400)),
                    NameSite = MyRandom.RandomString(MyRandom.RandomInt(15, 50)),
                    NameType = MyRandom.RandomString(MyRandom.RandomInt(5, 10)),
                    URL = MyRandom.RandomString(MyRandom.RandomInt(15, 40)),
                    ParamsParser = null
                }
            });

            SelectedWorkParser = WorksParser.First();
        }
    }

    #region Задачи парсера

    private IEnumerable<WorkParser>? _WorksParser;

    public IEnumerable<WorkParser>? WorksParser { get => _WorksParser; set => Set(ref _WorksParser, value); }

    #endregion

    #region Выбранная задача

    private WorkParser? _SelectedWorkParser;

    public WorkParser? SelectedWorkParser { get => _SelectedWorkParser!; set => Set(ref _SelectedWorkParser, value); }

    #endregion

    #region Команда обновления данных о выполняемых задачах

    private ICommand? _UpdateWorksParserCommand;

    public ICommand UpdateWorksParserCommand => _UpdateWorksParserCommand ??= new LambdaCommand(OnUpdateWorksParserCommandExecuted);

    private async void OnUpdateWorksParserCommandExecuted(object? p)
    {
        WorksParser = await _HttpListnerService.AllWorkGETAsync();
        if (WorksParser == null)
        {
            var dialog = new StringValueDialogWindow()
            {
                Title = "Ошибка",
                Header = "Ошибка при выполнении запроса",
                Message = String.Join("/n", _HttpListnerService.Errors),
                Owner = ActiveWindow
            };

            dialog.ShowDialog();
        }
        else
        {
            SelectedWorkParser = WorksParser.First();
        }
    }

    #endregion
}