using Microsoft.Extensions.Configuration;
using MoviesDemo.Core.Interfaces;

namespace MoviesDemo.Infrastructure.Validators
{
    public class ApiKeyValidator(IConfiguration configuration)
        : IApiKeyValidator
    {
        public const string ApiKey = "apiKey";

        public bool IsValidApiKey(string? apiKey)
            => apiKey == configuration.GetSection(ApiKey).Value;
    }
}
