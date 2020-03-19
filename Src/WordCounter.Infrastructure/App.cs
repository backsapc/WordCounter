using System;
using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;
using WordCounter.Application.Processing.CountWords;
using WordCounter.Infrastructure.Console;
using WordCounter.Infrastructure.EntityFramework;
using WordCounter.Infrastructure.EntityFramework.Provider;
using WordCounter.Infrastructure.EntityFramework.Saver;
using WordCounter.Infrastructure.File;
using WordCounter.Infrastructure.Settings.Processing;
using WordCounter.Infrastructure.Settings.Provider;
using WordCounter.Infrastructure.Settings.Saver;

namespace WordCounter.Infrastructure
{
    public class App: IApp
    {
        private readonly IProviderSettingsProvider _providerSettingsProvider;
        private readonly ISaverSettingsProvider _saverSettingsProvider;
        private readonly IProcessingSettingsProvider _processingSettingsProvider;

        public App(IProviderSettingsProvider providerSettingsProvider,
                   ISaverSettingsProvider saverSettingsProvider,
                   IProcessingSettingsProvider processingSettingsProvider)
        {
            _providerSettingsProvider = providerSettingsProvider;
            _saverSettingsProvider = saverSettingsProvider;
            _processingSettingsProvider = processingSettingsProvider;
        }
        
        public async Task RunAsync()
        {
            while (true)
            {
                ProviderOption providerOption = _providerSettingsProvider.GetProviderOption();
                ProviderSettings providerSettings = _providerSettingsProvider.GetProviderSettings(providerOption);
            
                SaverOption saverOption = _saverSettingsProvider.GetSaverOptions();
                SaverSettings saverSettings = _saverSettingsProvider.GetSaverSettings(saverOption);

                ProcessingOption processingOption = _processingSettingsProvider.GetProcessingOption();
            
                ITextProvider provider = GetTextProvider(providerSettings);
                ITextProcessor processor = GetTextProcessor(processingOption);
                IProcessingResultSaver saver = GetResultSaver(saverSettings);

                var text = provider.GetTextAsync(CancellationToken.None);
                IProcessingResult result = await processor.GetResultAsync(text, CancellationToken.None);
                await saver.SaveAsync(result, CancellationToken.None);
            }
        }

        private IProcessingResultSaver GetResultSaver(SaverSettings saverSettings)
        {
            return saverSettings.ProviderOption switch
            {
                SaverOption.Console => new ConsoleSaver(),
                SaverOption.File    => new FileResultSaver(saverSettings.FileName),
                SaverOption.Database when saverSettings.DatabaseType.HasValue => EfSaver.Create(
                    DbSettings.Create(saverSettings.DatabaseType.Value,
                                      saverSettings.ConnectionString)),
                _ => throw new NotImplementedException()
            };
        }

        private ITextProcessor GetTextProcessor(ProcessingOption processingOption)
        {
            return processingOption switch
            {
                ProcessingOption.CountWords => new CalculateWordsProcessor(),
                _                           => throw new NotImplementedException()
            };
        }

        private ITextProvider GetTextProvider(ProviderSettings providerSettings)
        {
            return providerSettings.ProviderOption switch
            {
                ProviderOption.Console => new ConsoleProvider(),
                ProviderOption.File    => new FileTextProvider(providerSettings.FileName),
                ProviderOption.Database when providerSettings.DatabaseType.HasValue => EfProvider.Create(
                    DbSettings.Create(providerSettings.DatabaseType.Value,
                                      providerSettings.ConnectionString)),
                _ => throw new NotImplementedException()
            };
        }
    }
}