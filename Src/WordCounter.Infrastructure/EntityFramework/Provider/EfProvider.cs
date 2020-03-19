using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WordCounter.Application;

namespace WordCounter.Infrastructure.EntityFramework.Provider
{
    public class EfProvider : ITextProvider
    {
        private readonly DbSettings _dbSettings;
        
        private EfProvider(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }
        
        public IAsyncEnumerable<string> GetTextAsync(CancellationToken token)
        {
            using var context = new InputContext(_dbSettings);

            return context.ProcessTexts
                          .AsAsyncEnumerable()
                          .Select(x => x.Text);
        }

        public static EfProvider Create(DbSettings settings)
        {
            return new EfProvider(settings);
        }
    }
}