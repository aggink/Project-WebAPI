using Company.WebAPI.Infrastructure.Working;
using Company.WebAPI.Infrastructure.Working.Base;

namespace Company.WebAPI.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Dependency Injection Registration
    /// </summary>
    public partial class DependencyContainer
    {
        /// <summary>
        /// Register 
        /// </summary>
        /// <param name="services"></param>
        public static void Common(IServiceCollection services)
        {
            #region Working

            services.AddSingleton<IBackgroundTaskQueue<BackgroundParser>, BackgroundTaskQueue<BackgroundParser>>();
            services.AddTransient<BackgroundParser>();

            #endregion
        }
    }
}