using FluentValidation;
using MediatR;
using MoviesDemo.Application.Queries.SearchMovies;

namespace MoviesDemo.Endpoints
{
    public static class MoviesEndpoints
    {
        public const string ApiKey = "apiKey";
        public const string MoviesAPIName = "api/movies";
        public const string MoviesTags = "Movies";
        public const string SearchMovies = "/searchMovies/";

        public static IEndpointRouteBuilder MapMoviesRoutes(this IEndpointRouteBuilder app, IConfiguration configuration)
        {
            var group = app.MapGroup(MoviesAPIName).WithTags(MoviesTags);

            group.MapGet(SearchMovies, async (IMediator mediator, IValidator<SearchMoviesQuery> validator, string searchString, string apiKey, CancellationToken cancellationToken) =>
            {
                var query = new SearchMoviesQuery(searchString);

                var result = await validator.ValidateAsync(query);

                if (!result.IsValid)
                    return Results.ValidationProblem(result.ToDictionary());

                var movies = await mediator.Send(query, cancellationToken);
                return movies is not null && movies.Any() ? Results.Ok(movies) : Results.Ok(new List<Core.Entities.MoviesEntity>());
            });

            return app;
        }
    }
}
