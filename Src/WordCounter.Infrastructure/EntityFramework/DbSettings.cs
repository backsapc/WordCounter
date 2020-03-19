namespace WordCounter.Infrastructure.EntityFramework
{
    public class DbSettings
    {
        public DbSettings(DatabaseType databaseType, string connectionString)
        {
            DatabaseType = databaseType;
            ConnectionString = connectionString;
        }
        
        public DatabaseType DatabaseType { get; }
        public string ConnectionString { get; }

        public static DbSettings Create(DatabaseType databaseType, string connectionString)
        {
            return new DbSettings(databaseType, connectionString);
        }
    }
}