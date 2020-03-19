using WordCounter.Infrastructure.EntityFramework;

namespace WordCounter.Infrastructure.Settings.Provider
{
    public class ProviderSettings
    {
        private ProviderSettings(ProviderOption providerOption, 
                                 string? connectionString = null, 
                                 DatabaseType? databaseType = null, 
                                 string? fileName = null)
        {
            ProviderOption = providerOption;
            ConnectionString = connectionString;
            DatabaseType = databaseType;
            FileName = fileName;
        }
        
        public ProviderOption ProviderOption { get; }
        public string? ConnectionString { get; }
        public DatabaseType? DatabaseType { get; } 
        public string? FileName { get; }

        public static ProviderSettings CreateConsoleSettings()
        {
            return new ProviderSettings(ProviderOption.Console);
        }
        
        public static ProviderSettings CreateDatabaseSettings(string connectionString, DatabaseType databaseType)
        {
            return new ProviderSettings(ProviderOption.Database, connectionString, databaseType);
        }
        
        public static ProviderSettings CreateFileSettings(string fileName)
        {
            return new ProviderSettings(ProviderOption.File, fileName: fileName);
        }
    }
}