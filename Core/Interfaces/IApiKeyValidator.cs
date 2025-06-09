namespace MoviesDemo.Core.Interfaces
{
    public interface IApiKeyValidator
    {
        bool IsValidApiKey(string? apiKey);
    }
}
