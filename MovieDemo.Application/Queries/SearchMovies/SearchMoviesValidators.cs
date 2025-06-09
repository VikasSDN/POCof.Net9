using FluentValidation;

namespace MoviesDemo.Application.Queries.SearchMovies
{
    public sealed class SearchMoviesValidators : AbstractValidator<SearchMoviesQuery>
    {
        public SearchMoviesValidators()
        {
            RuleFor(c => c.searchTitle).MustAsync(async (searchTitle, CancellationToken) =>
            {
                return string.IsNullOrWhiteSpace(searchTitle) ? false : true;

            }).WithMessage("Bad Request");
        }
    }
}
