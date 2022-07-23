using Company.WPF.Infrastructure.Common.VirtualizingCollection;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.Product;

namespace Company.WPF.Infrastructure.Providers;

public class BulatProductProvider : IVirtualizingCollection<BulatProduct>
{
    private readonly IHttpListnerService _HttpListnerService;

    public BulatProductProvider(IHttpListnerService httpListerService)
    {
        _HttpListnerService = httpListerService;
    }

    public async Task<(IList<BulatProduct>? page, int count)> FetchPage(int pageSize, int pageIndex)
    {
        var result = await _HttpListnerService.BulatProductGETAsync(pageIndex, pageSize);
        if (result == null) throw new ArgumentNullException(nameof(result));

        return (result!.Products.ToList(), result!.Count);
    }
}

public class RamisProductProvider : IVirtualizingCollection<RamisProduct>
{
    private readonly IHttpListnerService _HttpListnerService;

    public RamisProductProvider(IHttpListnerService httpListerService)
    {
        _HttpListnerService = httpListerService;
    }

    public async Task<(IList<RamisProduct>? page, int count)> FetchPage(int pageSize, int pageIndex)
    {
        var result = await _HttpListnerService.RamisProductGETAsync(pageIndex, pageSize);
        if (result == null) throw new ArgumentNullException(nameof(result));

        return (result!.Products.ToList(), result!.Count);
    }
}

public class ChipCartProductProvider : IVirtualizingCollection<ChipCartProduct>
{
    private readonly IHttpListnerService _HttpListnerService;

    public ChipCartProductProvider(IHttpListnerService httpListerService)
    {
        _HttpListnerService = httpListerService;
    }

    public async Task<(IList<ChipCartProduct>? page, int count)> FetchPage(int pageSize, int pageIndex)
    {
        var result = await _HttpListnerService.ChipCartProductGETAsync(pageIndex, pageSize);
        if (result == null) throw new ArgumentNullException(nameof(result));

        return (result!.Products.ToList(), result!.Count);
    }
}

public class ZipZipProductProvider : IVirtualizingCollection<ZipZipProduct>
{
    private readonly IHttpListnerService _HttpListnerService;

    public ZipZipProductProvider(IHttpListnerService httpListerService)
    {
        _HttpListnerService = httpListerService;
    }

    public async Task<(IList<ZipZipProduct>? page, int count)> FetchPage(int pageSize, int pageIndex)
    {
        var result = await _HttpListnerService.ZipZipProductGETAsync(pageIndex, pageSize);
        if (result == null) throw new ArgumentNullException(nameof(result));

        return (result!.Products.ToList(), result!.Count);
    }
}