using System.Threading;
using System.Threading.Tasks;
using WordCounter.Application;
using WordCounter.Application.Processing;

namespace WordCounter.Infrastructure.EntityFramework.Saver
{
    public class EfSaver : IProcessingResultSaver
    {
        private readonly DbSettings _dbSettings;

        public EfSaver(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public async Task SaveAsync(IProcessingResult result, CancellationToken token)
        {
            using var context = new OutputContext(_dbSettings);

            var newResult = new ProcessingResult
            {
                ProcessingResultValue = result.GetStringRepresentation()
            };
            
            await context.ProcessingResults.AddAsync(newResult, token);
            await context.SaveChangesAsync(token);
        }
    }
}