using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EvalTask.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddConfig<T>(this IServiceCollection services, IConfiguration configuration,
            string section, out T variable) where T : class
        {
            variable = configuration.GetSection(section).Get<T>();
            services.AddSingleton(variable);
        }
    }
}