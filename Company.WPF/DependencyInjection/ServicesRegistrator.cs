using Company.WPF.Infrastructure.Common.VirtualizingCollection;
using Company.WPF.Infrastructure.Providers;
using Company.WPF.Infrastructure.Services;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.Product;
using Company.WPF.ViewModels.Base;
using Company.WPF.ViewModels.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Company.WPF.DependencyInjection;

public static class ServicesRegistrator
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IHttpListnerService, HttpListnerService>();
        services.AddTransient<IUserDialogService, UserDialogService>();
        services.AddSingleton<IMessenger, Messenger>();

        services.AddTransient<IVirtualizingCollection<BulatProduct>, BulatProductProvider>();
        services.AddTransient<IVirtualizingCollection<RamisProduct>, RamisProductProvider>();
        services.AddTransient<IVirtualizingCollection<ChipCartProduct>, ChipCartProductProvider>();
        services.AddTransient<IVirtualizingCollection<ZipZipProduct>, ZipZipProductProvider>();

        return services;
    }
}