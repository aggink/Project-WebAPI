using Calabonga.UnitOfWork;
using Company.Data.DbContexts;
using Company.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.WebAPI.AppStart.ConfigServices
{
    public class ConfigureServiceBase
    {
        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conf"></param>
        public static void Configure(IServiceCollection services, IConfiguration conf)
        {
            #region AddDbContext

            services.AddDbContext<ParserDbContext>(options =>
                options.UseSqlServer(conf.GetConnectionString("ParserDbConnection")));

            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(conf.GetConnectionString("ProductDbConnection")));

            #endregion

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            #region AddUnitOfWork

            services.AddUnitOfWork<ParserDbContext>();
            services.AddUnitOfWork<ProductDbContext>();

            #endregion

            services.AddMemoryCache();
            services.AddRouting();
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddOptions();
            services.AddLocalization();
            services.AddHttpContextAccessor();
            services.AddResponseCaching();
            services.AddAntiforgery();
        }
    }
}
