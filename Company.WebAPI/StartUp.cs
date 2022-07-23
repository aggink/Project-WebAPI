using Company.WebAPI.AppStart.Configs;
using Company.WebAPI.AppStart.ConfigServices;
using Company.WebAPI.Infrastructure.DependencyInjection;

namespace Company.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration conf)
        {
            Configuration = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServiceBase.Configure(services, Configuration);
            ConfigureServicesSwagger.ConfigureServices(services, Configuration);

            DependencyContainer.Common(services);
            DependencyContainer.EntityManagers(services);
            DependencyContainer.EntityProviders(services);
            DependencyContainer.EntityServices(services);
            DependencyContainer.EntityRepositories(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AutoMapper.IConfigurationProvider mapper)
        {
            ConfigureCommon.Configure(app, env, mapper);
            ConfigureEndpoints.Configure(app);
        }
    }
}
