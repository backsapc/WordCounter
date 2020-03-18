namespace WordCounter.Infrastructure.EntityFramework.Saver
{
    public interface ISaverDbSettingsProvider
    {
        DbSettings GetSettings();
    }
}