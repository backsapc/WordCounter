using System;
using WordCounter.Infrastructure.EntityFramework;

namespace WordCounter.Infrastructure.Settings.Saver
{
    public class ConsoleSaverSettingsProvider: SettingsProviderBase, ISaverSettingsProvider
    {
        public SaverOption GetSaverOptions()
        {
            return MatchOptions("Where would you like to save processing result to?", new []
            {
                new Option<SaverOption>(1, "Console", SaverOption.Console),
                new Option<SaverOption>(2, "File", SaverOption.File),
                new Option<SaverOption>(3, "Database", SaverOption.Database),
            });
        }

        public SaverSettings GetSaverSettings(SaverOption saverOption)
        {
            return saverOption switch
            {
                SaverOption.Console  => GetConsoleSaverSettings(),
                SaverOption.File     => GetFileSaverSettings(),
                SaverOption.Database => GetDatabaseSaverSettings(),
                _                    => throw new NotImplementedException()
            };
        }
        
        private SaverSettings GetConsoleSaverSettings()
        {
            return SaverSettings.CreateConsoleSettings();
        }

        private SaverSettings GetFileSaverSettings()
        {
            System.Console.WriteLine("Enter file name: ");
            var fileName = System.Console.ReadLine();
            
            return SaverSettings.CreateFileSettings(fileName);
        }

        private SaverSettings GetDatabaseSaverSettings()
        {
            DatabaseType databaseType = MatchOptions("Select database type: ", new []
            {
                new Option<DatabaseType>(1, "MSSQL", DatabaseType.Mssql),
                new Option<DatabaseType>(2, "PostgreSQL", DatabaseType.PostgreSql),
                new Option<DatabaseType>(3, "In-Memory", DatabaseType.InMemory),
            });

            System.Console.WriteLine("Enter connection string: ");
            var connectionString = System.Console.ReadLine();
            
            return SaverSettings.CreateDatabaseSettings(connectionString, databaseType);
        }
    }
}