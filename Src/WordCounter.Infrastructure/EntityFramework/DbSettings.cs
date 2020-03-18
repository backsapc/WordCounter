namespace WordCounter.Infrastructure.EntityFramework
{
    public class DbSettings
    {
        public DatabaseType DatabaseType { get; set; }
        public string ConnectionString { get; set; }
    }
}