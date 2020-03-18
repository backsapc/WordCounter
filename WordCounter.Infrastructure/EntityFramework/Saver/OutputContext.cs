using System;
using Microsoft.EntityFrameworkCore;

namespace WordCounter.Infrastructure.EntityFramework.Saver
{
    public class OutputContext : DbContext
    {
        private readonly DbSettings _settings;

        public OutputContext(DbSettings settings)
        {
            _settings = settings;
        }
        
        public DbSet<ProcessingResult> ProcessingResults { get; set; }
        
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
            modelBuilder.Entity<ProcessingResult>()
                        .HasKey(x => x.Id);
        }
    }
}