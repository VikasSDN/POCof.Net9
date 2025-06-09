using MoviesDemo.Application;
using MoviesDemo.Core;
using MoviesDemo.Infrastructure;
using MoviesDemo.Middleware;
using MoviesDemo.Middlewares;

namespace MoviesDemo
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddCoreDI(configuration)
                .AddApplicationDI()
                .AddInfrastructureDI();

            serviceCollection.AddTransient<ApiKeyValidatorMiddleware>();
            serviceCollection.AddTransient<ExceptionHandlingMiddleware>();

            return serviceCollection;
        }
    }
}
