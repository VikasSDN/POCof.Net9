using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MoviesDemo.Application.Abstraction.Behaviours;

namespace MoviesDemo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cf =>
            {
                cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cf.AddOpenBehavior(typeof(ValidationBehaviours<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
