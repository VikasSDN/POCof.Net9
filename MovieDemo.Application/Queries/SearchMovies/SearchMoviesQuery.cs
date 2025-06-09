using MediatR;
using MoviesDemo.Core.Entities;
using MoviesDemo.Core.Interfaces;

namespace MoviesDemo.Application.Queries.SearchMovies
{
    public record SearchMoviesQuery(string searchTitle) : IRequest<List<MoviesEntity>>;

    public class SearchMoviesQueryHandler(IMoviesRepository moviesRepository) : IRequestHandler<SearchMoviesQuery, List<MoviesEntity>>
    {
        public async Task<List<MoviesEntity>> Handle(SearchMoviesQuery request, CancellationToken cancellationToken)
        {
            return await moviesRepository.SearchMoviesByTitle(request.searchTitle, cancellationToken);
        }
    }
}
