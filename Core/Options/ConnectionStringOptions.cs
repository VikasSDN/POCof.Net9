namespace MoviesDemo.Core.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";

        public string? MoviesDb { get; set; }
    }
}
