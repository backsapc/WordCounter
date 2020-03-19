namespace WordCounter.Infrastructure.Settings.Provider
{
    public interface IProviderSettingsProvider
    {
        ProviderOption GetProviderOption();
        ProviderSettings GetProviderSettings(ProviderOption providerOption);
    }
}