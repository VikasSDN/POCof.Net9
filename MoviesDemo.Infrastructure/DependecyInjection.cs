using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MoviesDemo.Core.Interfaces;
using MoviesDemo.Core.Options;
using MoviesDemo.Infrastructure.Data;
using MoviesDemo.Infrastructure.Repositories;
using MoviesDemo.Infrastructure.Validators;

namespace MoviesDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.MoviesDb);
            });

            service.AddScoped<IApiKeyValidator, ApiKeyValidator>();
            service.AddScoped<IMoviesRepository, MoviesRepository>();

            return service;
        }
    }
}
