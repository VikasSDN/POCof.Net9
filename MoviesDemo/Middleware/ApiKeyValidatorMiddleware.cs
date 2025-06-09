using System.Net;
using MoviesDemo.Core.Interfaces;

namespace MoviesDemo.Middlewares
{
    public class ApiKeyValidatorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var endpoint = context.GetEndpoint();
            var isApiCall = IsApiCall(endpoint?.DisplayName);

            if (isApiCall && !IsValidApiKey(context))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    status = (int)HttpStatusCode.Unauthorized,
                    message = "Provided Api key is not valid."
                });

                return;
            }

            await next(context);
        }

        private static bool IsValidApiKey(HttpContext context)
        {
            var apiKeyValidator = context
                 .RequestServices
                 .GetService<IApiKeyValidator>();

            var apiKey = context
                .Request
                .Query
                .FirstOrDefault(x => string.Equals(x.Key, "apikey", StringComparison.InvariantCultureIgnoreCase))
                .Value;

            if (apiKeyValidator != null
                && apiKeyValidator.IsValidApiKey(apiKey))
                return true;

            return false;
        }

        private static bool IsApiCall(string? displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                return false;

            return displayName
                .Split(' ')
                .Select(x => x.ToLower())
                .Any(x => x.StartsWith("api/") || x.StartsWith("/api/"));
        }
    }
}
