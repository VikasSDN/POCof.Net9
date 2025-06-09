using Microsoft.EntityFrameworkCore;
using MoviesDemo.Core.Entities;
using MoviesDemo.Core.Interfaces;
using MoviesDemo.Infrastructure.Data;

namespace MoviesDemo.Infrastructure.Repositories
{
    public class MoviesRepository(ApplicationDbContext dbContext) : IMoviesRepository
    {
        public async Task<IEnumerable<MoviesEntity>> GetMovies(CancellationToken cancellationToken = default)
        {
            try
            {
                return await dbContext.Movies.AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new List<MoviesEntity>
                {
                    new MoviesEntity { Title = ex.StackTrace, ReleaseYear = DateTime.UtcNow, posterImagePath = ex.Message }
                };
            }
        }

        public async Task<List<MoviesEntity>> SearchMoviesByTitle(string searchTitle, CancellationToken cancellationToken = default)
        {
            try
            {
                return await dbContext.Movies.AsNoTracking().Where(x => x.Title.Contains(searchTitle)).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return new List<MoviesEntity>
                {
                    new MoviesEntity { Title = ex.StackTrace, ReleaseYear = DateTime.UtcNow, posterImagePath = ex.Message }
                };
            }
        }
    }
}
