using WordCounter.Infrastructure.EntityFramework;

namespace WordCounter.Infrastructure.Settings.Saver
{
    public class SaverSettings
    {
        private SaverSettings(SaverOption providerOption, 
                              string? connectionString = null, 
                              DatabaseType? databaseType = null, 
                              string? fileName = null)
        {
            ProviderOption = providerOption;
            ConnectionString = connectionString;
            DatabaseType = databaseType;
            FileName = fileName;
        }
        
        public SaverOption ProviderOption { get; }
        public string? ConnectionString { get; }
        public DatabaseType? DatabaseType { get; } 
        public string? FileName { get; }

        public static SaverSettings CreateConsoleSettings()
        {
            return new SaverSettings(SaverOption.Console);
        }
        
        public static SaverSettings CreateDatabaseSettings(string connectionString, DatabaseType databaseType)
        {
            return new SaverSettings(SaverOption.Database, connectionString, databaseType);
        }
        
        public static SaverSettings CreateFileSettings(string fileName)
        {
            return new SaverSettings(SaverOption.File, fileName: fileName);
        }
    }
}