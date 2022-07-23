using Company.WPF.Models.Product;
using Company.WPF.ViewModels;
using Company.WPF.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Company.WPF.DependencyInjection;

public static class ViewModelsRegistrator
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<WorkParserViewModel>();
        services.AddSingleton<PropertyParserViewModel>();

        services.AddSingleton<ParserScanResultsViewModel<BulatProduct>>();
        services.AddSingleton<ParserScanResultsViewModel<RamisProduct>>();
        services.AddSingleton<ParserScanResultsViewModel<ChipCartProduct>>();
        services.AddSingleton<ParserScanResultsViewModel<ZipZipProduct>>();

        #region Windows

        services.AddTransient<CreateOrUpdateFieldParserViewModel>();
        services.AddTransient<CreateOrUpdatePropertyParserViewModel>();

        #endregion

        return services;
    }
}