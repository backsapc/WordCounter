using WordCounter.Infrastructure.EntityFramework;
using WordCounter.Infrastructure.EntityFramework.Provider;

namespace WordCounter
{
    public class ConsoleInputDbSettingsProvider: IProviderDbSettingsProvider
    {
        public DbSettings GetSettings()
        {
            throw new System.NotImplementedException();
        }
    }
}