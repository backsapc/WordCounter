namespace WordCounter.Infrastructure.EntityFramework.Provider
{
    public interface IProviderDbSettingsProvider
    {
        DbSettings GetSettings();
    }
}