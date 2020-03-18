using WordCounter.Infrastructure.EntityFramework;
using WordCounter.Infrastructure.EntityFramework.Provider;

namespace WordCounter.Infrastructure
{
    public class ConsoleInputDbSettingsProvider: IProviderDbSettingsProvider
    {
        public DbSettings GetSettings()
        {
            throw new System.NotImplementedException();
        }
    }
}