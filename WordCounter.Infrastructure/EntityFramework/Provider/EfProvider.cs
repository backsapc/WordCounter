using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WordCounter.Application;

namespace WordCounter.Infrastructure.EntityFramework.Provider
{
    public class EfProvider : ITextProvider
    {
        private readonly IProviderDbSettingsProvider _saverDbSettingsProvider;

        public EfProvider(IProviderDbSettingsProvider saverDbSettingsProvider)
        {
            _saverDbSettingsProvider = saverDbSettingsProvider;
        }
        
        public IAsyncEnumerable<string> GetTextAsync(CancellationToken token)
        {
            DbSettings settings = _saverDbSettingsProvider.GetSettings();
            using var context = new InputContext(settings);

            return context.ProcessTexts
                          .AsAsyncEnumerable()
                          .Select(x => x.Text);
        }
    }
}