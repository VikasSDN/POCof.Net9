using MoviesDemo.Core.Entities;

namespace MoviesDemo.Core.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MoviesEntity>> GetMovies(CancellationToken cancellationToken = default);
        Task<List<MoviesEntity>> SearchMoviesByTitle(string searchTitle, CancellationToken cancellationToken = default);
    }
}
