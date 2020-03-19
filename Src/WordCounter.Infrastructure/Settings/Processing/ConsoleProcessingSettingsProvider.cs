namespace WordCounter.Infrastructure.Settings.Processing
{
    public class ConsoleProcessingSettingsProvider : SettingsProviderBase, IProcessingSettingsProvider
    {
        public ProcessingOption GetProcessingOption()
        {
            return MatchOptions("What kind of processing would you like to apply?", new[]
            {
                new Option<ProcessingOption>(1, "Count Words", ProcessingOption.CountWords)
            });
        }
    }
}