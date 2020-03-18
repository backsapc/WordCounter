using System;
using Microsoft.EntityFrameworkCore;

namespace WordCounter.Infrastructure.EntityFramework.Provider
{
    public class InputContext : DbContext
    {
        private readonly DbSettings _settings;

        public InputContext(DbSettings settings)
        {
            _settings = settings;
        }
        
        public DbSet<ProcessText> ProcessTexts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_settings.DatabaseType)
            {
                case DatabaseType.Mssql:
                    optionsBuilder.UseSqlServer(_settings.ConnectionString);
                    break;
                case DatabaseType.PostgreSql:
                    optionsBuilder.UseNpgsql(_settings.ConnectionString);
                    break;
                case DatabaseType.InMemory:
                    optionsBuilder.UseInMemoryDatabase("in-memory");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_settings.DatabaseType));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessText>()
                        .HasKey(x => x.Id);
        }
    }
}