using Company.WebAPI.AppStart;
using Company.WebAPI.AppStart.Configs;
using Company.WebAPI.AppStart.ConfigServices;

namespace Company.WebAPI;

public class Startup
{
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration conf)
    {
        Configuration = conf;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBaseConfigureServices(Configuration);
        services.AddSwaggerConfigureServices(Configuration);
        
        services.AddCommonConfigureServices();
        services.AddManagersConfigureServices();
        services.AddProvidersConfigureServices();
        services.AddRepositoriesConfigureServices();
        services.AddServicesConfigureServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AutoMapper.IConfigurationProvider mapper)
    {
        app.AddCommonConfigure(env, mapper);
        app.AddEndpointsConfigure();
    }
}