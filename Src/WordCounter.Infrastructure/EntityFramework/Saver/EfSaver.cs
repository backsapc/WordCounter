using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure.EntityFramework.Saver
{
    public class EfSaver : IProcessingResultSaver
    {
        private readonly ISaverDbSettingsProvider _saverDbSettingsProvider;

        public EfSaver(ISaverDbSettingsProvider saverDbSettingsProvider)
        {
            _saverDbSettingsProvider = saverDbSettingsProvider;
        }

        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            DbSettings settings = _saverDbSettingsProvider.GetSettings();
            using var context = new OutputContext(settings);

            var newResult = new ProcessingResult
            {
                ProcessingResultValue = result.GetStringRepresentation()
            };
            
            await context.ProcessingResults.AddAsync(newResult, token);
            await context.SaveChangesAsync(token);
        }
    }
}