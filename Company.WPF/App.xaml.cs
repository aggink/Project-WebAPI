using Company.WPF.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace Company.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    public static Window? FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);
    public static Window? ActiveWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);


    public static bool IsDevelopment { get; private set; } = true;
    public static bool IsDesignMode { get; private set; } = true;

    private static IHost? __Host;
    public static IHost Host => __Host ?? Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
    public static IServiceProvider Services => Host.Services;

    protected override async void OnStartup(StartupEventArgs e)
    {
        IsDesignMode = false;
        var host = Host;
        base.OnStartup(e);

        await host.StartAsync().ConfigureAwait(false);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        using (Host) await Host.StopAsync().ConfigureAwait(false);
        __Host = null;
    }

    public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.AddServices();
        services.AddViewModels();
    }
}