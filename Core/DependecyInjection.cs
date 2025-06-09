using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesDemo.Core.Options;

namespace MoviesDemo.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

            return service;
        }
    }
}
