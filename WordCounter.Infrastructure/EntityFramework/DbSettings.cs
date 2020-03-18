namespace WordCounter.Infrastructure.EntityFramework
{
    public enum DatabaseType
    {
        Mssql,
        PostgreSql,
        InMemory
    }
    
    public class DbSettings
    {
        public DatabaseType DatabaseType { get; set; }
        public string ConnectionString { get; set; }
    }
}