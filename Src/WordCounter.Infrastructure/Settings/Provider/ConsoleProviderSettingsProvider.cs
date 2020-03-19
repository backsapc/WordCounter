using System;
using WordCounter.Infrastructure.EntityFramework;

namespace WordCounter.Infrastructure.Settings.Provider
{
    public class ConsoleProviderSettingsProvider : SettingsProviderBase, IProviderSettingsProvider
    {
        public ProviderOption GetProviderOption()
        {
            return MatchOptions("Where would you like to load text from?", new []
            {
                new Option<ProviderOption>(1, "Console", ProviderOption.Console),
                new Option<ProviderOption>(2, "File", ProviderOption.File),
                new Option<ProviderOption>(3, "Database", ProviderOption.Database),
            });
        }
        
        public ProviderSettings GetProviderSettings(ProviderOption providerOption)
        {
            return providerOption switch
            {
                ProviderOption.Console  => GetConsoleProviderSettings(),
                ProviderOption.File     => GetFileProviderSettings(),
                ProviderOption.Database => GetDatabaseProviderSettings(),
                _                       => throw new NotImplementedException()
            };
        }
        
        private ProviderSettings GetDatabaseProviderSettings()
        {
            DatabaseType databaseType = MatchOptions("Select database type: ", new []
            {
                new Option<DatabaseType>(1, "MSSQL", DatabaseType.Mssql),
                new Option<DatabaseType>(2, "PostgreSQL", DatabaseType.PostgreSql),
                new Option<DatabaseType>(3, "In-Memory", DatabaseType.InMemory),
            });

            System.Console.WriteLine("Enter connection string: ");
            var connectionString = System.Console.ReadLine();
            
            return ProviderSettings.CreateDatabaseSettings(connectionString, databaseType);
        }

        private ProviderSettings GetFileProviderSettings()
        { 
            System.Console.WriteLine("Enter file name: ");
            var fileName = System.Console.ReadLine();
            
            return ProviderSettings.CreateFileSettings(fileName);
        }

        private ProviderSettings GetConsoleProviderSettings()
        {
            return ProviderSettings.CreateConsoleSettings();
        }
    }
}