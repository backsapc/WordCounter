namespace WordCounter.Infrastructure.Settings.Saver
{
    public interface ISaverSettingsProvider
    {
        SaverOption GetSaverOptions();
        SaverSettings GetSaverSettings(SaverOption providerOption);
    }
}