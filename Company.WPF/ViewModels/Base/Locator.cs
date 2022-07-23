using Company.WPF.Models.Product;
using Company.WPF.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Company.WPF.ViewModels.Base;

/// <summary>
/// Передача данных о ViewModels черех статический класс
/// </summary>
public class Locator
{
    public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
    public WorkParserViewModel WorkParserViewModel => App.Services.GetRequiredService<WorkParserViewModel>();
    public PropertyParserViewModel PropertyParserViewModel => App.Services.GetRequiredService<PropertyParserViewModel>();
    public ParserScanResultsViewModel<BulatProduct> BulatParserScanResultsViewModel => App.Services.GetRequiredService<ParserScanResultsViewModel<BulatProduct>>();
    public ParserScanResultsViewModel<RamisProduct> RamisParserScanResultsViewModel => App.Services.GetRequiredService<ParserScanResultsViewModel<RamisProduct>>();
    public ParserScanResultsViewModel<ZipZipProduct> ZipZipParserScanResultsViewModel => App.Services.GetRequiredService<ParserScanResultsViewModel<ZipZipProduct>>();
    public ParserScanResultsViewModel<ChipCartProduct> ChipCartParserScanResultsViewModel => App.Services.GetRequiredService<ParserScanResultsViewModel<ChipCartProduct>>();

    #region Windows

    public CreateOrUpdateFieldParserViewModel CreateOrUpdateFieldParserViewModel => App.Services.GetRequiredService<CreateOrUpdateFieldParserViewModel>();
    public CreateOrUpdatePropertyParserViewModel CreateOrUpdatePropertyParserViewModel => App.Services.GetRequiredService<CreateOrUpdatePropertyParserViewModel>();

    #endregion
}