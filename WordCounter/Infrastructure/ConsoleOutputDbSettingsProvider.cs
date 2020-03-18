using System;
using System.Collections.Generic;
using System.Linq;
using WordCounter.Infrastructure.EntityFramework;
using WordCounter.Infrastructure.EntityFramework.Saver;

namespace WordCounter
{
    public class ConsoleOutputDbSettingsProvider: ISaverDbSettingsProvider
    {
        private readonly IReadOnlyList<(int DbIndex, string DbName, DatabaseType DbType)> _databases =
            new List<(int DbIndex, string DbName, DatabaseType DbType)>
            {
                (1, "MSSQL", DatabaseType.Mssql),
                (2, "Postgre", DatabaseType.PostgreSql),
                (3, "In-Memory", DatabaseType.InMemory)
            };
        
        public DbSettings GetSettings()
        {
            var dbList = _databases.Select(x => $"{x.DbIndex}. {x.DbName}").ToList();
            var dbIndices = _databases.Select(x => x.DbIndex.ToString()).ToList();
            Console.WriteLine("Please select your database:");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }

            while (true)
            {
                var index = Console.ReadLine();
                if (!dbIndices.Contains(index))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
            
            
        }
    }
}