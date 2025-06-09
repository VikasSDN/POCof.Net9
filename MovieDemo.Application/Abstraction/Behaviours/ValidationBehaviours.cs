using FluentValidation;
using MediatR;
using MoviesDemo.Application.Exceptions;

namespace MoviesDemo.Application.Abstraction.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        public readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var ValidationFailure = await Task.WhenAll(_validators.Select(async validator => await validator.ValidateAsync(context)));

            var errors = ValidationFailure
                .Where(result => !result.IsValid)
                .SelectMany(result => result.Errors)
                .Select(failedValidations => new ValidationError(
                    failedValidations.PropertyName,
                    failedValidations.ErrorMessage
                ))
                .ToList();

            if (errors.Any())
                throw new Exceptions.ValidationException(errors);


            var response = await next();

            return response;
        }
    }
}
